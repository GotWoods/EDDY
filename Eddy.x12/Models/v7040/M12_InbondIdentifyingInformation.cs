using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7040;

[Segment("M12")]
public class M12_InBondIdentifyingInformation : EdiX12Segment
{
	[Position(01)]
	public string CustomsEntryTypeCode { get; set; }

	[Position(02)]
	public string CustomsEntryNumber { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string LocationIdentifier2 { get; set; }

	[Position(05)]
	public int? CustomsShipmentValue { get; set; }

	[Position(06)]
	public string InBondControlNumber { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(11)]
	public string VesselName { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(13)]
	public string Date { get; set; }

	[Position(14)]
	public string LocationIdentifier3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M12_InBondIdentifyingInformation>(this);
		validator.Required(x=>x.CustomsEntryTypeCode);
		validator.OnlyOneOf(x=>x.CustomsEntryNumber, x=>x.InBondControlNumber);
		validator.ARequiresB(x=>x.InBondControlNumber, x=>x.ReferenceIdentificationQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TransportationMethodTypeCode, x=>x.VesselName);
		validator.Length(x => x.CustomsEntryTypeCode, 2, 3);
		validator.Length(x => x.CustomsEntryNumber, 1, 50);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.CustomsShipmentValue, 2, 9);
		validator.Length(x => x.InBondControlNumber, 1, 50);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.VesselName, 2, 50);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.LocationIdentifier3, 1, 30);
		return validator.Results;
	}
}
