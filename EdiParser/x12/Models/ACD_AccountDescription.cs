using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("ACD")]
public class ACD_AccountDescription : EdiX12Segment
{
    [Position(01)] public string AccountRelationshipCode { get; set; }

    [Position(02)] public string RatingRemarksCode { get; set; }

    [Position(03)] public string LoanTypeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ACD_AccountDescription>(this);
        validator.Length(x => x.AccountRelationshipCode, 1, 2);
        validator.Length(x => x.RatingRemarksCode, 2);
        validator.Length(x => x.LoanTypeCode, 1, 2);
        return validator.Results;
    }
}