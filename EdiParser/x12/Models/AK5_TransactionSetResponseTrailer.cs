using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("AK5")]
public class AK5_TransactionSetResponseTrailer : EdiX12Segment
{
    [Position(01)]
    public string TransactionSetAcknowledgmentCode { get; set; }

    [Position(02)]
    public string TransactionSetSyntaxErrorCode { get; set; }

    [Position(03)]
    public string TransactionSetSyntaxErrorCode2 { get; set; }

    [Position(04)]
    public string TransactionSetSyntaxErrorCode3 { get; set; }

    [Position(05)]
    public string TransactionSetSyntaxErrorCode4 { get; set; }

    [Position(06)]
    public string TransactionSetSyntaxErrorCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AK5_TransactionSetResponseTrailer>(this);
        validator.Required(x => x.TransactionSetAcknowledgmentCode);
        validator.Length(x => x.TransactionSetAcknowledgmentCode, 1);
        validator.Length(x => x.TransactionSetSyntaxErrorCode, 1, 3);
        validator.Length(x => x.TransactionSetSyntaxErrorCode2, 1, 3);
        validator.Length(x => x.TransactionSetSyntaxErrorCode3, 1, 3);
        validator.Length(x => x.TransactionSetSyntaxErrorCode4, 1, 3);
        validator.Length(x => x.TransactionSetSyntaxErrorCode5, 1, 3);
        return validator.Results;
    }
}