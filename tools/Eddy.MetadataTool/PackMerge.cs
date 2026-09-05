using System.Text.Json.Nodes;

namespace Eddy.MetadataTool;

/// <summary>Deep-merges metadata pack JSON documents, later documents winning per key. Objects
/// are merged key by key (recursively); anything else (arrays, strings, numbers) is replaced
/// wholesale by the later value when present. This gives the exact behaviour the pack format
/// needs: dataElements/composites/segments are replaced whole per id when a later file redefines
/// one, while codes.&lt;dataElement&gt; merges per code value so a later file can override one
/// code's description while leaving the rest, and add new codes, without repeating them all.</summary>
public static class PackMerge
{
    public static JsonObject DeepMerge(JsonObject a, JsonObject b)
    {
        var result = new JsonObject();
        foreach (var (key, value) in a)
            result[key] = value?.DeepClone();
        foreach (var (key, value) in b)
        {
            if (result[key] is JsonObject existing && value is JsonObject incoming)
                result[key] = DeepMerge(existing, incoming);
            else
                result[key] = value?.DeepClone();
        }
        return result;
    }
}
