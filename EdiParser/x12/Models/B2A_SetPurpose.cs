using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("B2A")]
public class B2A_SetPurpose : EdiX12Segment
{
    /// <summary>
    /// Code identifying why this transaction is being sent (Original, Delete, Change, Etc)
    /// </summary>
    [Position(1)]
    public string TransactionSetPurposeCode { get; set; }

    /// <summary>
    /// The application of this transaction (e.g. Vessel Import Manifest, Arrival Notice, Bill Of Lading, etc)
    /// </summary>
    [Position(2)]
    public string ApplicationTypeCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<B2A_SetPurpose>(this);
        validator.Length(x => x.TransactionSetPurposeCode, 2, 2);
        validator.Length(x => x.ApplicationTypeCode, 2);

        validator.Required(x=>x.TransactionSetPurposeCode);

        return validator.Results;
    }


}