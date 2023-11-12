using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M12")]
public class M12_InBondIdentifyingInformation : EdiX12Segment
{
	[Position(01)]
	public string InBondTypeCode { get; set; }

	[Position(02)]
	public string EntryNumber { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string LocationIdentifier2 { get; set; }

	[Position(05)]
	public string CustomsShipmentValue { get; set; }

	[Position(06)]
	public string InBondControlNumber { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(09)]
	public string ReferenceNumber { get; set; }

	[Position(10)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(11)]
	public string VesselName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M12_InBondIdentifyingInformation>(this);
		validator.Required(x=>x.InBondTypeCode);
		validator.AtLeastOneIsRequired(x=>x.EntryNumber, x=>x.InBondControlNumber);
		validator.ARequiresB(x=>x.InBondControlNumber, x=>x.ReferenceNumberQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TransportationMethodTypeCode, x=>x.VesselName);
		validator.Length(x => x.InBondTypeCode, 2);
		validator.Length(x => x.EntryNumber, 1, 15);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.CustomsShipmentValue, 2, 8);
		validator.Length(x => x.InBondControlNumber, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.VesselName, 2, 28);
		return validator.Results;
	}
}
