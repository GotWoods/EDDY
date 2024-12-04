using System;
using System.Globalization;
using System.Text;
using Eddy.Core;
using Eddy.x12.Mapping;

namespace Eddy.x12.Models;

public class GenericInterchangeControlHeader
{
    public string AuthorizationInformationQualifier { get; set; }

    public string AuthorizationInformation { get; set; }

    public string SecurityInformationQualifier { get; set; }

    public string SecurityInformation { get; set; }

    public string InterchangeSenderIDQualifier { get; set; }

    public string InterchangeSenderID { get; set; }

    public string InterchangeReceiverIDQualifier { get; set; }

    public string InterchangeReceiverID { get; set; }

    public string InterchangeDate { get; set; }

    public string InterchangeTime { get; set; }

    public string RepetitionSeparator { get; set; }

    public string InterchangeControlVersionNumberCode { get; set; }

    public int? InterchangeControlNumber { get; set; }

    public string AcknowledgmentRequestedCode { get; set; }

    public string InterchangeUsageIndicatorCode { get; set; }

    public string ComponentDataElementSeparator { get; set; }


    public DateTime GetDateTime()
    {
        return x12DateTimeParser.Parse(InterchangeDate, InterchangeTime, SupportedDateFormats.All, SupportedTimeFormats.FourDigit);
    }

    public static GenericInterchangeControlHeader FromString(string line)
    {
        var result = new GenericInterchangeControlHeader();
        result.DataElementSeparator = Convert.ToChar(line.Substring(3, 1));
        var parts = line.Split(result.DataElementSeparator);
        
        if (parts.Length != 17)
            throw new InvalidFileFormatException("ISA must have exactly 17 elements");

        result.AuthorizationInformationQualifier = parts[1];
        if (result.AuthorizationInformationQualifier.Length != 2)
            throw new InvalidFileFormatException("ISA AuthorizationInformationQualifier must be 2 characters long");
        
        result.AuthorizationInformation = parts[2];
        if (result.AuthorizationInformation.Length != 10)
            throw new InvalidFileFormatException("ISA AuthorizationInformation must be 10 characters long");

        result.SecurityInformationQualifier = parts[3];
        if (result.SecurityInformationQualifier.Length != 2)
            throw new InvalidFileFormatException("ISA SecurityInformationQualifier must be 2 characters long");

        result.SecurityInformation = parts[4];
        if (result.SecurityInformation.Length != 10)
            throw new InvalidFileFormatException("ISA AuthorizationInformation must be 10 characters long");

        result.InterchangeSenderIDQualifier = parts[5];
        if (result.InterchangeSenderIDQualifier.Length != 2)
            throw new InvalidFileFormatException("ISA InterchangeSenderIDQualifier must be 2 characters long");
        
        result.InterchangeSenderID = parts[6];
        if (result.InterchangeSenderID.Length != 15)
            throw new InvalidFileFormatException("ISA AuthorizationInformation must be 15 characters long");
        
        result.InterchangeReceiverIDQualifier = parts[7];
        if (result.InterchangeReceiverIDQualifier.Length != 2)
            throw new InvalidFileFormatException("ISA InterchangeReceiverIDQualifier must be 2 characters long");

        result.InterchangeReceiverID = parts[8];
        if (result.InterchangeReceiverID.Length != 15)
            throw new InvalidFileFormatException("ISA InterchangeReceiverID must be 15 characters long");
        
        result.InterchangeDate = parts[9];
        if (result.InterchangeDate.Length != 6)
            throw new InvalidFileFormatException("ISA InterchangeDate must be 6 characters long");
        
        result.InterchangeTime = parts[10];
        if (result.InterchangeTime.Length != 4)
            throw new InvalidFileFormatException("ISA InterchangeTime must be 10 characters long");
        
        result.RepetitionSeparator = parts[11];
        if (result.RepetitionSeparator.Length != 1)
            throw new InvalidFileFormatException("ISA Interchange Control Standards Identifier must be 10 characters long");
        
        result.InterchangeControlVersionNumberCode = parts[12].TrimStart('0'); //we don't care about leading zeros
        if (parts[12].Length != 5)
            throw new InvalidFileFormatException("ISA InterchangeControlVersionNumberCode must be 5 characters long");
        
        result.InterchangeControlNumber = int.Parse(parts[13]);
        if (parts[13].Length != 9)
            throw new InvalidFileFormatException("ISA InterchangeControlNumber must be 9 characters long");

        result.AcknowledgmentRequestedCode = parts[14];
        if (result.AcknowledgmentRequestedCode.Length != 1)
            throw new InvalidFileFormatException("ISA AcknowledgmentRequestedCode must be 1 characters long");
        
        result.InterchangeUsageIndicatorCode = parts[15];
        if (result.InterchangeUsageIndicatorCode.Length != 1)
            throw new InvalidFileFormatException("ISA InterchangeUsageIndicatorCode must be 1 characters long");

        //this is going to break as this has the final element in it which is the line separator
        if (parts[16].Length != 2)
            throw new InvalidFileFormatException("ISA ComponentDataElementSeparator must be 1 characters long");

        result.ComponentDataElementSeparator = parts[16].Substring(0,1);
        result.ElementSeparator = Convert.ToChar(parts[16].Substring(1, 1));

        // options.Separator = isa.Substring(103, 1);
        // //component separator is at 104
        // options.LineEnding = isa.Substring(105, 1);
        // //options.LineEnding = result.IsaInterchangeControlHeader.ComponentElementSeparator.Substring(1); //strip the leading > character
        // //result.IsaInterchangeControlHeader = Map.MapObject<ISA_InterchangeControlHeader>(isa, options);
        // var version = isa.Substring(86, 3) + "0";

        // if (string.IsNullOrWhiteSpace(options.LineEnding))
        //     options.LineEnding = "\n";

        return result;
    }

    public char DataElementSeparator { get; set; }

    public char ElementSeparator { get; set; }

    //ISA is fixed width so we don't use the default mapper for this
    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("ISA" + DataElementSeparator);
        result.Append(AuthorizationInformationQualifier + DataElementSeparator);  //2 characters
        result.Append(ToFixedLengthString(AuthorizationInformation, 10, ' ') + DataElementSeparator);  //10 characters
        result.Append(ToFixedLengthString(SecurityInformationQualifier, 2, ' ') + DataElementSeparator);  //2 characters
        result.Append(ToFixedLengthString(SecurityInformation, 10, ' ') + DataElementSeparator);  //10 characters
        result.Append(ToFixedLengthString(InterchangeSenderIDQualifier, 2, ' ') + DataElementSeparator);  //2 characters
        result.Append(ToFixedLengthString(InterchangeSenderID, 15, ' ') + DataElementSeparator);  //15 characters
        result.Append(ToFixedLengthString(InterchangeReceiverIDQualifier, 2, ' ') + DataElementSeparator);  //2 characters
        result.Append(ToFixedLengthString(InterchangeReceiverID, 15, ' ') + DataElementSeparator);  //15 characters
        result.Append(ToFixedLengthString(InterchangeDate, 6, ' ') + DataElementSeparator);  //6 characters
        result.Append(ToFixedLengthString(InterchangeTime, 4, ' ') + DataElementSeparator);  //4 characters

        if (int.Parse(this.InterchangeControlVersionNumberCode) <= 4010) //older versions used U to indicate it was an x12 document. later replaced with RepetitionSeparator
            result.Append("U" + DataElementSeparator);
        else
            result.Append(ToFixedLengthString(RepetitionSeparator, 1, ' ') + DataElementSeparator); //1 characters (should this be options.Separator

        result.Append(ToFixedLengthString(InterchangeControlVersionNumberCode.ToString(), 5, '0') + DataElementSeparator);  //5 characters
        result.Append(ToFixedLengthString(InterchangeControlNumber.ToString(), 9, '0') + DataElementSeparator);  //9 characters
        result.Append(ToFixedLengthString(AcknowledgmentRequestedCode, 1, ' ') + DataElementSeparator);  //1 characters
        result.Append(InterchangeUsageIndicatorCode + DataElementSeparator);  //1 characters
        result.Append(ComponentDataElementSeparator);  //1 characters
        var resultAsString = result.ToString();
        if (!resultAsString.EndsWith(ElementSeparator.ToString()))
            resultAsString += ElementSeparator.ToString();
        return resultAsString;

    }

    private string ToFixedLengthString(string input, int length, char paddingCharacter)
    {
        if (string.IsNullOrEmpty(input))
            return "".PadRight(length, paddingCharacter);
        if (paddingCharacter == ' ')//strings get padded right but numbers get padded left
            return input.PadRight(length, paddingCharacter);

        return input.PadLeft(length, paddingCharacter);
    }
}