using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AEI")]
public class AEI_EquipmentInformationSummary : EdiX12Segment
{
    [Position(01)] public string EquipmentDescriptionCode { get; set; }

    [Position(02)] public decimal? Quantity { get; set; }

    [Position(03)] public string YesNoConditionOrResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AEI_EquipmentInformationSummary>(this);
        validator.Required(x => x.EquipmentDescriptionCode);
        validator.Required(x => x.Quantity);
        validator.Required(x => x.YesNoConditionOrResponseCode);
        validator.Length(x => x.EquipmentDescriptionCode, 2);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        return validator.Results;
    }
}