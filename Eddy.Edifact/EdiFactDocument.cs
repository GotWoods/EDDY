using System.Collections.Generic;
using System.Linq;
using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;

namespace Eddy.Edifact;

public class FunctionalGroup
{
    public List<Message> Messages { get; set; } = new();
}

public class Message
{
    public List<EdifactSegment> Segments { get; set; } = new();
}

public class EdiFactDocument
{
    public GenericInterchangeControlHeader InterchangeControlHeader { get; set; }

    public List<FunctionalGroup> FunctionalGroups { get; set; } = new();

    // public GenericFunctionalGroupHeader GsHeader { get; set; }
    public List<ValidationResult> ValidationErrors { get; set; } = new();

    public bool IsValid => !ValidationErrors.Any();
    //public List<BitVector32.Section> Sections { get; set; } = new();

    public static EdiFactDocument Parse(string data)
    {
        var lineNumber = 1;
        data = data.Replace("\r\n", "\n"); //normalize newlines
        var document = new EdiFactDocument();

        //if UNA is provided, we need to load the options of the document
        var options = new MapOptions();
        if (data.Substring(0, 3).ToUpperInvariant() == "UNA")
        {
            options.ComponentElementSeparator = data[3].ToString();
            options.Separator = data[4].ToString();
            options.LineEnding = data[8].ToString();
            //TODO: decimal notation character, release character, repetition character
        }

        var lines = data.Split(options.LineEnding.ToCharArray());

        //What is UNS used for?
        /*
         * UNA
         * UNB (Mandatory Interchange Control Header. Contains sender/recipient/time/control number)
         *  UNG  (Optional Group)
         *      UNH (Mandatory Message Header. Contains type (e.g. APERAK) as well as version like D00A)
         *          Data here
         *      UNT
         *  UNE (Group trailer)
         * UNZ (Interchange Control Trailer)
         */

        FunctionalGroup currentGroup = null;
        Message currentMessage = null;
        var currentStandardsVersion = "";

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (trimmedLine.Length == 0)
                continue;

            if (trimmedLine.EndsWith(options.LineEnding))
                trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - options.LineEnding.Length);

            if (trimmedLine.StartsWith("UNA")) //UNA defines options and is at the start of the file
                continue; //skip the UNA line (if it exists, we parsed it above)

            if (trimmedLine.StartsWith("UNB")) //Document header line
            {
                document.InterchangeControlHeader = Map.MapObject<GenericInterchangeControlHeader>(line, options);
            }
            else if (trimmedLine.StartsWith("UNG"))
            {
                currentGroup = new FunctionalGroup();
                document.FunctionalGroups.Add(currentGroup);
                // var st = Map.MapObject<ST_TransactionSetHeader>(trimmedLine, options);
                // currentSection = new BitVector32.Section();
                // currentSection.SectionType = st.TransactionSetIdentifierCode;
                // currentSection.TransactionSetControlNumber = st.TransactionSetControlNumber;
                // r2.Sections.Add(currentSection);
            }
            else if (trimmedLine.StartsWith("UNE"))
            {
                currentGroup = null;
                // var se = Map.MapObject<SE_TransactionSetTrailer>(trimmedLine, options);
                //
                // if (se.NumberOfIncludedSegments != currentSection.Segments.Count + 2)
                //     r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.TransactionSetSegmentCountMismatch, se.NumberOfIncludedSegments.ToString(), (currentSection.Segments.Count + 2).ToString()) } });
                //
                // if (se.TransactionSetControlNumber != currentSection.TransactionSetControlNumber)
                //     r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.TransactionSetControlNumberMismatch, currentSection.TransactionSetControlNumber, se.TransactionSetControlNumber) } });
            }
            else if (trimmedLine.StartsWith("UNH"))
            {
                if (currentGroup == null)
                {
                    currentGroup = new FunctionalGroup();
                    document.FunctionalGroups.Add(currentGroup);
                }

                currentMessage = new Message();
                currentGroup.Messages.Add(currentMessage);

                //TODO: current standards version loaded here
                currentStandardsVersion = "D96A";

                //var ge = Map.MapObject<GenericFunctionalGroupTrailer>(trimmedLine, options);
                // if (ge.NumberOfTransactionSetsIncluded != r2.Sections.Count)
                //     r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.FunctionalGroupSectionCountMismatch, ge.NumberOfTransactionSetsIncluded.ToString(), r2.Sections.Count.ToString()) } });
                //
                // if (ge.GroupControlNumber != int.Parse(r2.GsHeader.GroupControlNumber))
                //     r2.ValidationErrors.Add(new ValidationResult() { LineNumber = lineNumber, Errors = { new Error(ErrorCodes.FunctionalGroupControlNumberMismatch, r2.GsHeader.GroupControlNumber, ge.GroupControlNumber.ToString()) } });
            }
            else if (trimmedLine.StartsWith("UNT"))
            {
                currentMessage = null;
            }
            else if (currentMessage != null) //parse the actual line then
            {
                var segment = EdiSectionParserFactory.Parse(currentStandardsVersion, trimmedLine, options);
                if (segment != null)
                {
                    var validationResult = segment.Validate();
                    if (!validationResult.IsValid)
                    {
                        validationResult.LineNumber = lineNumber;
                        document.ValidationErrors.Add(validationResult);
                    }
                    currentMessage.Segments.Add(segment);
                }
            }
            lineNumber++;
        }

        return document;
    }

    // public string ToString(MapOptions options)
    // {
    //     var sb = new StringBuilder();
    //     //Should we be creating a footer array at the same time?
    //     sb.Append(this.InterchangeControlHeader.ToString());
    //     sb.Append(Map.SegmentToString(this.GsHeader, options));
    //
    //     foreach (var section in Sections)
    //     {
    //         var header = new ST_TransactionSetHeader();
    //         header.TransactionSetControlNumber = section.TransactionSetControlNumber;
    //         header.TransactionSetIdentifierCode = section.SectionType;
    //         var data = Map.SegmentToString(header, options);
    //         if (!string.IsNullOrEmpty(data))
    //             sb.Append(data);
    //
    //         var lines = 0;
    //         foreach (var segment in section.Segments)
    //         {
    //             if (segment != null)
    //                 sb.Append(Map.SegmentToString(segment, options));
    //             lines++;
    //         }
    //         var footer = new SE_TransactionSetTrailer();
    //         footer.NumberOfIncludedSegments = lines + 2; //ST/SE counts
    //         footer.TransactionSetControlNumber = section.TransactionSetControlNumber;
    //         sb.Append(Map.SegmentToString(footer, options));
    //     }
    //
    //     var groupEnd = new GenericFunctionalGroupTrailer();
    //     groupEnd.NumberOfTransactionSetsIncluded = Sections.Count;
    //     groupEnd.GroupControlNumber = int.Parse(GsHeader.GroupControlNumber);
    //     sb.Append(Map.SegmentToString(groupEnd, options));
    //
    //     var isaEnd = new GenericInterchangeControlTrailer();
    //     isaEnd.InterchangeControlNumber = this.InterchangeControlHeader.InterchangeControlNumber.ToString().PadLeft(9, '0');
    //     isaEnd.NumberOfIncludedFunctionalGroups = 1;
    //     sb.Append(Map.SegmentToString(isaEnd, options));
    //     return sb.ToString();
    // }
}