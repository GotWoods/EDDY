using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

using SE_TransactionSetTrailer = Eddy.x12.Models.SE_TransactionSetTrailer;
using ST_TransactionSetHeader = Eddy.x12.Models.ST_TransactionSetHeader;

namespace Eddy.x12;

public class x12Document
{
    public GenericInterchangeControlHeader InterchangeControlHeader { get; set; }
    public GenericFunctionalGroupHeader GsHeader { get; set; }
    public List<ValidationResult> ValidationErrors { get; set; } = new();
    public bool IsValid => !ValidationErrors.Any();

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
            footer.NumberOfIncludedSegments = lines; //ST/SE counts
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

        var lineNumber = 1;
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
        //line 1 validation here

        var lines = data.Split(options.LineEnding.ToCharArray());
        r2.GsHeader = Map.MapObject<GenericFunctionalGroupHeader>(lines[1], options);
       
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
            else if (trimmedLine.StartsWith("SE"))
            {
                var se = Map.MapObject<SE_TransactionSetTrailer>(trimmedLine, options);

                if (se.NumberOfIncludedSegments != currentSection.Segments.Count+2)
                    r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.TransactionSetSegmentCountMismatch, se.NumberOfIncludedSegments.ToString(), (currentSection.Segments.Count+2).ToString()) } });

                if (se.TransactionSetControlNumber != currentSection.TransactionSetControlNumber)
                    r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.TransactionSetControlNumberMismatch, currentSection.TransactionSetControlNumber, se.TransactionSetControlNumber) } });


            }
            else if (trimmedLine.StartsWith("GE"))
            {
                var ge = Map.MapObject<GenericFunctionalGroupTrailer>(trimmedLine, options);
                if (ge.NumberOfTransactionSetsIncluded != r2.Sections.Count)
                    r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.FunctionalGroupSectionCountMismatch, ge.NumberOfTransactionSetsIncluded.ToString(), r2.Sections.Count.ToString()) } });

                if (ge.GroupControlNumber != int.Parse(r2.GsHeader.GroupControlNumber))
                    r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.FunctionalGroupControlNumberMismatch, r2.GsHeader.GroupControlNumber, ge.GroupControlNumber.ToString()) } });
            }
            // else if (trimmedLine.EndsWith("IEA"))
            // {
            //     var iea = Map.MapObject<GenericInterchangeControlTrailer>(trimmedLine, options);
            //     if (iea.InterchangeControlNumber != r2.InterchangeControlHeader.InterchangeControlNumber.ToString().PadLeft(9, '0'))
            //         r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.InterchangeControlNumberMismatch, r2.InterchangeControlHeader.InterchangeControlNumber.ToString().PadLeft(9, '0'), iea.InterchangeControlNumber) } });
            // }
            else if (currentSection != null)
            {
                var ediX12Segment = EdiSectionParserFactory.Parse(options.StandardsVersion,trimmedLine, options);
                var validationResult = ediX12Segment.Validate();
                if (!validationResult.IsValid)
                {
                    validationResult.LineNumber = lineNumber;
                    r2.ValidationErrors.Add(validationResult);
                }

                currentSection.Segments.Add(ediX12Segment);
            }
            lineNumber++;
        }
        return r2;
    }

    public List<Section> Sections { get; set; } = new();
}
