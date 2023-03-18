using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("N4")]
public class N4_GeographicLocation : EdiX12Segment
{
    [Position(01)]
    public string CityName { get; set; }

    [Position(02)]
    public string StateOrProvinceCode { get; set; }

    [Position(03)]
    public string PostalCode { get; set; }

    [Position(04)]
    public string CountryCode { get; set; }

    [Position(05)]
    public string LocationQualifier { get; set; }

    [Position(06)]
    public string LocationIdentifier { get; set; }

    [Position(07)]
    public string CountrySubdivisionCode { get; set; }

    [Position(08)]
    public string PostalCodeFormatted { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<N4_GeographicLocation>(this);
        validator.OnlyOneOf(x => x.StateOrProvinceCode, x => x.CountrySubdivisionCode);
        validator.OnlyOneOf(x => x.PostalCode, x => x.PostalCodeFormatted);
        validator.ARequiresB(x => x.LocationIdentifier, x => x.LocationQualifier);
        validator.ARequiresB(x => x.CountrySubdivisionCode, x => x.CountryCode);
        validator.Length(x => x.CityName, 2, 30);
        validator.Length(x => x.StateOrProvinceCode, 2);
        validator.Length(x => x.PostalCode, 3, 15);
        validator.Length(x => x.CountryCode, 2, 3);
        validator.Length(x => x.LocationQualifier, 1, 2);
        validator.Length(x => x.LocationIdentifier, 1, 30);
        validator.Length(x => x.CountrySubdivisionCode, 1, 3);
        validator.Length(x => x.PostalCodeFormatted, 3, 20);
        return validator.Results;
    }
}