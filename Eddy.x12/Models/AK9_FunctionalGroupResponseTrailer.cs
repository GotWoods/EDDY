using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AK9")]
public class AK9_FunctionalGroupResponseTrailer : EdiX12Segment
{
    [Position(01)]
    public string FunctionalGroupAcknowledgeCode { get; set; }

    [Position(02)]
    public int? NumberOfTransactionSetsIncluded { get; set; }

    [Position(03)]
    public int? NumberOfReceivedTransactionSets { get; set; }

    [Position(04)]
    public int? NumberOfAcceptedTransactionSets { get; set; }

    [Position(05)]
    public string FunctionalGroupSyntaxErrorCode { get; set; }

    [Position(06)]
    public string FunctionalGroupSyntaxErrorCode2 { get; set; }

    [Position(07)]
    public string FunctionalGroupSyntaxErrorCode3 { get; set; }

    [Position(08)]
    public string FunctionalGroupSyntaxErrorCode4 { get; set; }

    [Position(09)]
    public string FunctionalGroupSyntaxErrorCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AK9_FunctionalGroupResponseTrailer>(this);
        validator.Required(x => x.FunctionalGroupAcknowledgeCode);
        validator.Required(x => x.NumberOfTransactionSetsIncluded);
        validator.Required(x => x.NumberOfReceivedTransactionSets);
        validator.Required(x => x.NumberOfAcceptedTransactionSets);
        validator.Length(x => x.FunctionalGroupAcknowledgeCode, 1);
        validator.Length(x => x.NumberOfTransactionSetsIncluded, 1, 6);
        validator.Length(x => x.NumberOfReceivedTransactionSets, 1, 6);
        validator.Length(x => x.NumberOfAcceptedTransactionSets, 1, 6);
        validator.Length(x => x.FunctionalGroupSyntaxErrorCode, 1, 3);
        validator.Length(x => x.FunctionalGroupSyntaxErrorCode2, 1, 3);
        validator.Length(x => x.FunctionalGroupSyntaxErrorCode3, 1, 3);
        validator.Length(x => x.FunctionalGroupSyntaxErrorCode4, 1, 3);
        validator.Length(x => x.FunctionalGroupSyntaxErrorCode5, 1, 3);
        return validator.Results;
    }
}