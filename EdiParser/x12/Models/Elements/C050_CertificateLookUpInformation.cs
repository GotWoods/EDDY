using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C050")]
public class C050_CertificateLookUpInformation : EdiX12Component
{
    [Position(00)]
    public string LookUpValueProtocolCode { get; set; }

    [Position(01)]
    public string FilterIDCode { get; set; }

    [Position(02)]
    public string VersionIdentifier { get; set; }

    [Position(03)]
    public string LookUpValue { get; set; }

    [Position(04)]
    public string LookUpValueProtocolCode2 { get; set; }

    [Position(05)]
    public string FilterIDCode2 { get; set; }

    [Position(06)]
    public string VersionIdentifier2 { get; set; }

    [Position(07)]
    public string LookUpValue2 { get; set; }

    [Position(08)]
    public string LookUpValueProtocolCode3 { get; set; }

    [Position(09)]
    public string FilterIDCode3 { get; set; }

    [Position(10)]
    public string VersionIdentifier3 { get; set; }

    [Position(11)]
    public string LookUpValue3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C050_CertificateLookUpInformation>(this);
        validator.Required(x => x.LookUpValueProtocolCode);
        validator.Required(x => x.FilterIDCode);
        validator.Required(x => x.VersionIdentifier);
        validator.Required(x => x.LookUpValue);
        validator.Length(x => x.LookUpValueProtocolCode, 2);
        validator.Length(x => x.FilterIDCode, 3);
        validator.Length(x => x.VersionIdentifier, 1, 30);
        validator.Length(x => x.LookUpValue, 1, 4096);
        validator.Length(x => x.LookUpValueProtocolCode2, 2);
        validator.Length(x => x.FilterIDCode2, 3);
        validator.Length(x => x.VersionIdentifier2, 1, 30);
        validator.Length(x => x.LookUpValue2, 1, 4096);
        validator.Length(x => x.LookUpValueProtocolCode3, 2);
        validator.Length(x => x.FilterIDCode3, 3);
        validator.Length(x => x.VersionIdentifier3, 1, 30);
        validator.Length(x => x.LookUpValue3, 1, 4096);
        return validator.Results;
    }
}