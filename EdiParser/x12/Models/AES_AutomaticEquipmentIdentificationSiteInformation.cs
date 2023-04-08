using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("AES")]
public class AES_AutomaticEquipmentIdentificationSiteInformation : EdiX12Segment
{
    [Position(01)] public string AutomaticEquipmentIdentificationSiteStatusCode { get; set; }

    [Position(02)] public string MovementTypeCode { get; set; }

    [Position(03)] public string TrainTerminationStatusCode { get; set; }

    [Position(04)] public string AutomaticEquipmentIdentificationConsistConfidenceLevelCode { get; set; }

    [Position(05)] public string IndustryCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AES_AutomaticEquipmentIdentificationSiteInformation>(this);
        validator.Required(x => x.AutomaticEquipmentIdentificationSiteStatusCode);
        validator.Required(x => x.MovementTypeCode);
        validator.Required(x => x.TrainTerminationStatusCode);
        validator.Required(x => x.AutomaticEquipmentIdentificationConsistConfidenceLevelCode);
        validator.Length(x => x.AutomaticEquipmentIdentificationSiteStatusCode, 1);
        validator.Length(x => x.MovementTypeCode, 1);
        validator.Length(x => x.TrainTerminationStatusCode, 1);
        validator.Length(x => x.AutomaticEquipmentIdentificationConsistConfidenceLevelCode, 1);
        validator.Length(x => x.IndustryCode, 1, 30);
        return validator.Results;
    }
}