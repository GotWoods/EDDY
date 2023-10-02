using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Eddy.Core;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

using SE_TransactionSetTrailer = Eddy.x12.Models.SE_TransactionSetTrailer;
using ST_TransactionSetHeader = Eddy.x12.Models.ST_TransactionSetHeader;

namespace Eddy.x12;

public class x12Document
{
    public GenericInterchangeControlHeader InterchangeControlHeader { get; set; }
    public GenericFunctionalGroupHeader GsHeader { get; set; }

    public string ToString(MapOptions options)
    {
        var sb = new StringBuilder();
        //Should we be creating a footer array at the same time?
        sb.Append(this.InterchangeControlHeader.ToString());
        sb.Append(Map.SegmentToString(this.GsHeader, options));

        foreach (var section in Sections)
        {
            var header = new ST_TransactionSetHeader();
            header.TransactionSetControlNumber = section.TransactionSetControlNumber;
            header.TransactionSetIdentifierCode = section.SectionType;
            var data = Map.SegmentToString(header, options);
            if (!string.IsNullOrEmpty(data))
                sb.Append(data);

            var lines = 0;
            foreach (var segment in section.Segments)
            {
                if (segment != null)
                    sb.Append(Map.SegmentToString(segment, options));
                lines++;
            }
            var footer = new SE_TransactionSetTrailer();
            footer.NumberOfIncludedSegments = lines +2; //ST/SE counts
            footer.TransactionSetControlNumber = section.TransactionSetControlNumber;
            sb.Append(Map.SegmentToString(footer, options));
        }

        var groupEnd = new GenericFunctionalGroupTrailer();
        groupEnd.NumberOfTransactionSetsIncluded = Sections.Count;
        groupEnd.GroupControlNumber = int.Parse(GsHeader.GroupControlNumber);
        sb.Append(Map.SegmentToString(groupEnd, options));
        
        var isaEnd = new GenericInterchangeControlTrailer();
        isaEnd.InterchangeControlNumber = this.InterchangeControlHeader.InterchangeControlNumber.ToString().PadLeft(9, '0');
        isaEnd.NumberOfIncludedFunctionalGroups = 1;
        sb.Append(Map.SegmentToString(isaEnd, options));
        return sb.ToString();
    }



    public static x12Document Parse(string data)
    {
        var allowedChars = "A-Za-z0-9!\"&'()*~+,\\-./:;?=\" ";
        var asciiChars = "\x07\x09\x0A\x0B\x0C\x0D\x1C\x1D\x1E\x1F\x01\x02\x03\x04\x05\x06\x11\x12\x13\x14\x15\x16\x17";
        var pattern = $"^[{allowedChars}{asciiChars}]*$"; // + asciiChars1 + asciiChars2 + "]*$";
        var regex = new Regex(pattern);
        var match = regex.Match(data);

        // if (!match.Success)
        //     throw new InvalidFileFormatException("Non ASCII characters detected in file at position " + (match.Index + match.Length));
        //

        data = data.Replace("\r\n", "\n"); //normalize newlines
        
        if (data.Length < 106)
            throw new InvalidFileFormatException($"Expected file to be at least 106 characters long but was {data.Length} characters");

        var r2 = new x12Document();
        r2.InterchangeControlHeader = GenericInterchangeControlHeader.FromString(data.Substring(0, 106)); //fixed length string

        var options = new MapOptions();
        options.Separator = r2.InterchangeControlHeader.DataElementSeparator.ToString();
        options.ComponentElementSeparator = r2.InterchangeControlHeader.ComponentDataElementSeparator;
        options.LineEnding = r2.InterchangeControlHeader.ElementSeparator.ToString();
        options.StandardsVersion = r2.InterchangeControlHeader.InterchangeControlVersionNumberCode + "0";

        var lines = data.Split(options.LineEnding.ToCharArray());

        r2.GsHeader = Map.MapObject<GenericFunctionalGroupHeader>(lines[1], options);

        //TODO: parse these lines in raw to get the parameters
        //result.GsHeader = GsHeaderFactory.FromVersion(version, lines[1], options); // Map.MapObject<GS_FunctionalGroupHeader>(lines[1],options);
        
        //var sections = new List<Section>();
        Section currentSection = null;
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (trimmedLine.Length == 0)
                continue;

            if (trimmedLine.EndsWith(options.LineEnding))
                trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - options.LineEnding.Length);

            if (trimmedLine.StartsWith("ST"))
            {
                var st = Map.MapObject<ST_TransactionSetHeader>(trimmedLine,options);
                currentSection = new Section();
                currentSection.SectionType = st.TransactionSetIdentifierCode;
                currentSection.TransactionSetControlNumber = st.TransactionSetControlNumber;
                r2.Sections.Add(currentSection);
            }
            else if (currentSection != null)
            {
                currentSection.Segments.Add(EdiSectionParserFactory.Parse(options.StandardsVersion,trimmedLine, options));
            }
            else if (trimmedLine.StartsWith("SE"))
            {
                var se = Map.MapObject<SE_TransactionSetTrailer>(trimmedLine, options);
                if (se.NumberOfIncludedSegments != currentSection.Segments.Count - 2)
                    throw new Exception($"SE said there would be {se.NumberOfIncludedSegments} but there were actually {currentSection.Segments.Count}");
                if (se.TransactionSetControlNumber != currentSection.TransactionSetControlNumber)
                    throw new Exception($"The starting control number ({currentSection.TransactionSetControlNumber}) did not match the ending control number ({se.TransactionSetControlNumber})");
                r2.Sections.Add(currentSection);
            }
        }
        return r2;
    }

    public List<Section> Sections { get; set; } = new();

    //public GS_FunctionalGroupHeader GsHeader { get; set; }

    //public ISA_InterchangeControlHeader IsaInterchangeControlHeader { get; set; }
}