using EdiParser.Attributes;

namespace EdiParser.EdiFact.Models.Elements;

public class S003_InterchangeRecipient : IElement
{
    [Position(1)]
    public string InterchangeRecipientIdentification { get; set; }

    [Position(2)]
    public string IdentificationCodeQualifier { get; set; }

    [Position(3)]
    public string InterchangeRecipientInternalIdentification { get; set; }

    [Position(4)]
    public string InterchangeRecipientInternalSubIdentification { get; set; }
}