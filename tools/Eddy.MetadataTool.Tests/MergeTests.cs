using System.Text.Json.Nodes;
using Xunit;

namespace Eddy.MetadataTool.Tests;

public class MergeTests
{
    [Fact]
    public void Later_file_overrides_a_description_and_adds_a_code_without_losing_the_rest()
    {
        var a = (JsonObject)JsonNode.Parse("""
            {
              "format": "eddy-metadata-pack/1",
              "standard": "EDIFACT",
              "version": "D96A",
              "codes": {
                "3035": { "BY": "", "SU": "" }
              }
            }
            """)!;

        var b = (JsonObject)JsonNode.Parse("""
            {
              "format": "eddy-metadata-pack/1",
              "standard": "EDIFACT",
              "version": "D96A",
              "codes": {
                "3035": { "BY": "Buyer", "DP": "Delivery party" }
              }
            }
            """)!;

        var merged = PackMerge.DeepMerge(a, b);
        var pack = PackJson.Parse(merged);

        var codes = pack.Codes["3035"];
        Assert.Equal(3, codes.Count);
        Assert.Equal("Buyer", codes["BY"]); // overridden by the later file
        Assert.Equal("", codes["SU"]); // untouched, kept from the first file
        Assert.Equal("Delivery party", codes["DP"]); // added by the later file
    }

    [Fact]
    public void Later_file_replaces_a_segment_definition_whole_when_it_redefines_the_same_id()
    {
        var a = (JsonObject)JsonNode.Parse("""
            {
              "format": "eddy-metadata-pack/1",
              "standard": "EDIFACT",
              "version": "D96A",
              "segments": {
                "NAD": { "name": "Old Name", "elements": [ { "pos": 1, "de": "3035", "req": "M" } ] }
              }
            }
            """)!;

        var b = (JsonObject)JsonNode.Parse("""
            {
              "format": "eddy-metadata-pack/1",
              "standard": "EDIFACT",
              "version": "D96A",
              "segments": {
                "NAD": { "name": "Name And Address", "elements": [ { "pos": 1, "de": "3035", "req": "M" }, { "pos": 2, "composite": "C082", "req": "C" } ] }
              }
            }
            """)!;

        var merged = PackMerge.DeepMerge(a, b);
        var pack = PackJson.Parse(merged);

        Assert.Equal("Name And Address", pack.Segments["NAD"].Name);
        Assert.Equal(2, pack.Segments["NAD"].Elements.Count);
    }
}
