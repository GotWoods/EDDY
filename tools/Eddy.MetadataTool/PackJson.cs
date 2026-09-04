using System.Text.Json;
using System.Text.Json.Nodes;

namespace Eddy.MetadataTool;

/// <summary>Reads and writes metadata packs per docs/metadata-packs.md, with sorted keys so
/// packs diff cleanly.</summary>
public static class PackJson
{
    private static readonly JsonSerializerOptions WriteOptions = new() { WriteIndented = true };

    public static MetadataPackModel Parse(JsonObject root)
    {
        var pack = new MetadataPackModel
        {
            Format = RequireString(root, "format"),
            Standard = RequireString(root, "standard"),
            Version = RequireString(root, "version"),
            Name = OptionalString(root, "name"),
            Provenance = OptionalString(root, "provenance"),
            License = OptionalString(root, "license"),
        };

        if (root["dataElements"] is JsonObject deObj)
        {
            foreach (var (key, value) in deObj)
            {
                var o = (JsonObject)(value ?? throw new FormatException($"dataElements.{key} is null"));
                pack.DataElements[key] = new DataElementDef
                {
                    Name = OptionalString(o, "name"),
                    Type = RequireString(o, "type"),
                    Min = OptionalInt(o, "min"),
                    Max = OptionalInt(o, "max"),
                };
            }
        }

        if (root["composites"] is JsonObject coObj)
            foreach (var (key, value) in coObj)
                pack.Composites[key] = ParseComponent(key, (JsonObject)(value ?? throw new FormatException($"composites.{key} is null")));

        if (root["segments"] is JsonObject segObj)
            foreach (var (key, value) in segObj)
                pack.Segments[key] = ParseComponent(key, (JsonObject)(value ?? throw new FormatException($"segments.{key} is null")));

        if (root["codes"] is JsonObject codesObj)
        {
            foreach (var (deKey, value) in codesObj)
            {
                var inner = (JsonObject)(value ?? throw new FormatException($"codes.{deKey} is null"));
                var map = new Dictionary<string, string>();
                foreach (var (code, desc) in inner)
                    map[code] = (string?)desc ?? "";
                pack.Codes[deKey] = map;
            }
        }

        return pack;
    }

    private static ComponentDef ParseComponent(string key, JsonObject o)
    {
        var component = new ComponentDef { Name = OptionalString(o, "name") };
        if (o["elements"] is JsonArray arr)
        {
            foreach (var el in arr)
            {
                var eo = (JsonObject)(el ?? throw new FormatException($"{key}: element is null"));
                component.Elements.Add(new ElementRef
                {
                    Pos = (int)(eo["pos"] ?? throw new FormatException($"{key}: element missing pos")),
                    De = OptionalString(eo, "de"),
                    Composite = OptionalString(eo, "composite"),
                    Req = OptionalString(eo, "req"),
                });
            }
        }
        return component;
    }

    private static string RequireString(JsonObject o, string key) =>
        (string?)o[key] ?? throw new FormatException($"missing required field '{key}'");

    private static string? OptionalString(JsonObject o, string key) => (string?)o[key];

    private static int? OptionalInt(JsonObject o, string key) => o[key] is null ? null : (int?)o[key];

    public static JsonObject ToJsonObject(MetadataPackModel pack)
    {
        var root = new JsonObject
        {
            ["format"] = pack.Format,
            ["standard"] = pack.Standard,
            ["version"] = pack.Version,
        };
        if (pack.Name is not null) root["name"] = pack.Name;
        if (pack.Provenance is not null) root["provenance"] = pack.Provenance;
        if (pack.License is not null) root["license"] = pack.License;

        if (pack.DataElements.Count > 0)
        {
            var obj = new JsonObject();
            foreach (var key in pack.DataElements.Keys.OrderBy(k => k, StringComparer.Ordinal))
            {
                var de = pack.DataElements[key];
                var deObj = new JsonObject();
                if (de.Name is not null) deObj["name"] = de.Name;
                deObj["type"] = de.Type;
                if (de.Min is not null) deObj["min"] = de.Min;
                if (de.Max is not null) deObj["max"] = de.Max;
                obj[key] = deObj;
            }
            root["dataElements"] = obj;
        }

        if (pack.Composites.Count > 0)
            root["composites"] = ComponentsToJson(pack.Composites);

        if (pack.Segments.Count > 0)
            root["segments"] = ComponentsToJson(pack.Segments);

        if (pack.Codes.Count > 0)
        {
            var obj = new JsonObject();
            foreach (var key in pack.Codes.Keys.OrderBy(k => k, StringComparer.Ordinal))
            {
                var inner = new JsonObject();
                foreach (var code in pack.Codes[key].Keys.OrderBy(k => k, StringComparer.Ordinal))
                    inner[code] = pack.Codes[key][code];
                obj[key] = inner;
            }
            root["codes"] = obj;
        }

        return root;
    }

    private static JsonObject ComponentsToJson(Dictionary<string, ComponentDef> components)
    {
        var obj = new JsonObject();
        foreach (var key in components.Keys.OrderBy(k => k, StringComparer.Ordinal))
        {
            var c = components[key];
            var cObj = new JsonObject();
            if (c.Name is not null) cObj["name"] = c.Name;
            var arr = new JsonArray();
            foreach (var el in c.Elements.OrderBy(e => e.Pos))
            {
                var eObj = new JsonObject { ["pos"] = el.Pos };
                if (el.De is not null) eObj["de"] = el.De;
                if (el.Composite is not null) eObj["composite"] = el.Composite;
                if (el.Req is not null) eObj["req"] = el.Req;
                arr.Add(eObj);
            }
            cObj["elements"] = arr;
            obj[key] = cObj;
        }
        return obj;
    }

    public static MetadataPackModel Load(string path)
    {
        var json = File.ReadAllText(path);
        var node = JsonNode.Parse(json) ?? throw new FormatException($"{path}: empty JSON document");
        return Parse((JsonObject)node);
    }

    public static void Save(MetadataPackModel pack, string path)
    {
        var json = ToJsonObject(pack);
        var directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        File.WriteAllText(path, json.ToJsonString(WriteOptions) + Environment.NewLine);
    }
}
