using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("F02")]
public class F02_IdentificationOfShipment : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification2 { get; set; }

	[Position(08)]
	public string VesselCode { get; set; }

	[Position(09)]
	public string VesselName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F02_IdentificationOfShipment>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.VesselCode, 1, 8);
		validator.Length(x => x.VesselName, 2, 28);
		return validator.Results;
	}
}
