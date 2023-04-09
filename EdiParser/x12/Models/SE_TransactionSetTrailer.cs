using System;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("SE")]
public class SE_TransactionSetTrailer : EdiX12Segment
{
    [Position(01)]
    public int? NumberOfIncludedSegments { get; set; }

    [Position(02)]
    public string TransactionSetControlNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<SE_TransactionSetTrailer>(this);
        validator.Required(x => x.NumberOfIncludedSegments);
        validator.Required(x => x.TransactionSetControlNumber);
        validator.Length(x => x.NumberOfIncludedSegments, 1, 10);
        validator.Length(x => x.TransactionSetControlNumber, 4, 9);
        return validator.Results;
    }

    
}