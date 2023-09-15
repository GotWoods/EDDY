using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

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
	public string ReferenceNumberQualifier { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(07)]
	public string ReferenceNumber2 { get; set; }

	[Position(08)]
	public string VesselCode { get; set; }

	[Position(09)]
	public string VesselName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F02_IdentificationOfShipment>(this);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.VesselCode, 1, 7);
		validator.Length(x => x.VesselName, 2, 28);
		return validator.Results;
	}
}
