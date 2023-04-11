using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("N7A")]
public class N7A_AccessorialEquipmentDetails : EdiX12Segment
{
    [Position(01)]
    public string LoadOrDeviceCode { get; set; }

    [Position(02)]
    public decimal? Length { get; set; }

    [Position(03)]
    public decimal? Diameter { get; set; }

    [Position(04)]
    public string HoseTypeCode { get; set; }

    [Position(05)]
    public decimal? Diameter2 { get; set; }

    [Position(06)]
    public decimal? Diameter3 { get; set; }

    [Position(07)]
    public string InletOrOutletMaterialTypeCode { get; set; }

    [Position(08)]
    public string InletOrOutletFittingTypeCode { get; set; }

    [Position(09)]
    public string MiscellaneousEquipmentCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<N7A_AccessorialEquipmentDetails>(this);
        validator.Length(x => x.LoadOrDeviceCode, 2);
        validator.Length(x => x.Length, 1, 8);
        validator.Length(x => x.Diameter, 1, 2);
        validator.Length(x => x.HoseTypeCode, 3);
        validator.Length(x => x.Diameter2, 1, 2);
        validator.Length(x => x.Diameter3, 1, 2);
        validator.Length(x => x.InletOrOutletMaterialTypeCode, 2);
        validator.Length(x => x.InletOrOutletFittingTypeCode, 2);
        validator.Length(x => x.MiscellaneousEquipmentCode, 2);
        return validator.Results;
    }
}