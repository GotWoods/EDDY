using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.x12;

public class x12Document
{

    public string ToString(MapOptions options)
    {
        var sb = new StringBuilder();
        //Should we be creating a footer array at the same time?
        sb.Append(this.IsaInterchangeControlHeader.ToString(options));
        sb.Append(Map.SegmentToString(GsHeader, options));
        foreach (var section in Sections)
        {
            var header = new ST_TransactionSetHeader();
            header.TransactionSetControlNumber = section.TransactionSetControlNumber;
            header.TransactionSetIdentifierCode = section.SectionType;
            sb.Append(Map.SegmentToString(header, options));
            var lines = 0;
            foreach (var segment in section.Segments)
            {
                sb.Append(Map.SegmentToString(segment, options));
                lines++;
            }
            var footer = new SE_TransactionSetTrailer();
            footer.NumberOfIncludedSegments = lines +2; //ST/SE counts
            footer.TransactionSetControlNumber = section.TransactionSetControlNumber;
            sb.Append(Map.SegmentToString(footer, options));
        }
        var groupEnd = new GE_FunctionalGroupTrailer();
        groupEnd.NumberOfTransactionSetsIncluded = Sections.Count;
        groupEnd.GroupControlNumber = int.Parse(GsHeader.GroupControlNumber);
        sb.Append(Map.SegmentToString(groupEnd, options));

        var isaEnd = new IEA_InterchangeControlTrailer();
        isaEnd.InterchangeControlNumber = this.IsaInterchangeControlHeader.InterchangeControlNumber;
        isaEnd.NumberOfIncludedFunctionalGroups = 1;
        sb.Append(Map.SegmentToString(isaEnd, options));
        return sb.ToString();
    }
    public static x12Document Parse(string data)
    {
        data = data.Replace("\r\n", "\n"); //normalize newlines
        //var lines = data.Split('\n');

        var options = new MapOptions();
        options.Separator = "*"; //x12 standard

        var result = new x12Document();

        var isa = data.Substring(0, 106); //fixed length string
        result.IsaInterchangeControlHeader = Map.MapObject<ISA_InterchangeControlHeader>(isa, options);
        options.LineEnding = result.IsaInterchangeControlHeader.ComponentElementSeparator.Substring(1); //strip the leading > character
        if (string.IsNullOrWhiteSpace(options.LineEnding))
            options.LineEnding = "\n";
        var lines = data.Split(options.LineEnding.ToCharArray());

        result.GsHeader = Map.MapObject<GS_FunctionalGroupHeader>(lines[1],options);
        if (result.GsHeader.ResponsibleAgencyCode == "X")
            options.StandardsVersion = result.GsHeader.VersionReleaseIndustryIdentifierCode;
        //GS can run from GS to GE (but a GE is not required)

        var sections = new List<Section>();
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
                result.Sections.Add(currentSection);
            }
            else if (currentSection != null)
            {
                currentSection.Segments.Add(EdiSectionParserFactory.Parse(trimmedLine, options));
            }
            else if (trimmedLine.StartsWith("SE"))
            {
                var se = Map.MapObject<SE_TransactionSetTrailer>(trimmedLine, options);
                if (se.NumberOfIncludedSegments != currentSection.Segments.Count - 2)
                    throw new Exception($"SE said there would be {se.NumberOfIncludedSegments} but there were actually {currentSection.Segments.Count}");
                if (se.TransactionSetControlNumber != currentSection.TransactionSetControlNumber)
                    throw new Exception($"The starting control number ({currentSection.TransactionSetControlNumber}) did not match the ending control number ({se.TransactionSetControlNumber})");
                result.Sections.Add(currentSection);
            }
        }
        return result;
    }

    public List<Section> Sections { get; set; } = new();

    public GS_FunctionalGroupHeader GsHeader { get; set; }

    public ISA_InterchangeControlHeader IsaInterchangeControlHeader { get; set; }
}