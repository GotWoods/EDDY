using EdiParser.x12;

namespace EdiParser.Tests;

public class EdiSerializer
{
    public void Deserialize(string input)
    {
        input = input.Replace("\r\n", "\n");
        var lines = input.Split('\n');
            
        if (lines[0].StartsWith("IsaHeader"))
        {
            var x = new x12Document();
            //x.Parse(lines);
        }
        //edifact would start with something different

    }
}