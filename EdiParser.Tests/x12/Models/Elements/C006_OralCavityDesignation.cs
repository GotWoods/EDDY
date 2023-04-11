using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models.Elements;

[Segment("C006")]
public class C006_OralCavityDesignation : EdiX12Component
{
    [Position(00)]
    public string OralCavityDesignationCode { get; set; }

    [Position(01)]
    public string OralCavityDesignationCode2 { get; set; }

    [Position(02)]
    public string OralCavityDesignationCode3 { get; set; }

    [Position(03)]
    public string OralCavityDesignationCode4 { get; set; }

    [Position(04)]
    public string OralCavityDesignationCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C006_OralCavityDesignation>(this);
        validator.Required(x => x.OralCavityDesignationCode);
        validator.Length(x => x.OralCavityDesignationCode, 1, 3);
        validator.Length(x => x.OralCavityDesignationCode2, 1, 3);
        validator.Length(x => x.OralCavityDesignationCode3, 1, 3);
        validator.Length(x => x.OralCavityDesignationCode4, 1, 3);
        validator.Length(x => x.OralCavityDesignationCode5, 1, 3);
        return validator.Results;
    }
}