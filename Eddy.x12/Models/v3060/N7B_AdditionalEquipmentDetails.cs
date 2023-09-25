using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("N7B")]
public class N7B_AdditionalEquipmentDetails : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfTankCompartments { get; set; }

	[Position(02)]
	public string LoadingOrDischargeLocationCode { get; set; }

	[Position(03)]
	public string VesselMaterialCode { get; set; }

	[Position(04)]
	public string GasketTypeCode { get; set; }

	[Position(05)]
	public string TrailerLiningTypeCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N7B_AdditionalEquipmentDetails>(this);
		validator.Length(x => x.NumberOfTankCompartments, 1, 2);
		validator.Length(x => x.LoadingOrDischargeLocationCode, 1);
		validator.Length(x => x.VesselMaterialCode, 3);
		validator.Length(x => x.GasketTypeCode, 3);
		validator.Length(x => x.TrailerLiningTypeCode, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
