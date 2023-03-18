using EdiParser.x12;
using EdiParser.x12.Mapping;

namespace EdiParser.EdiFact;

public class EdiFactDocument
{
    public static EdiFactDocument Parse(string data)
    {
        /*
         * UNA:+.? //optional
           UNB+UNOC:3+LY78+16390913+230127:0814+614720311 //mandatory File Header (UNZ ends this
          //UNG is a group header (UNE ends this)
         //UNH header (ended by UNT)
        //message
        //UNT end of message
        //UNE end of group
        //unz end of file
         */

        data = data.Replace("\r\n", "\n"); //normalize newlines
        var lines = data.Split('\n');

        var options = new MapOptions();
        options.Separator = "+"; //component seperator


        var result = new EdiFactDocument();
        return result;
    }
}