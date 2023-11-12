using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M12_InBondIdentifyingInformation>(this);
		validator.Required(x=>x.InBondTypeCode);
		validator.AtLeastOneIsRequired(x=>x.EntryNumber, x=>x.InBondControlNumber);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.CustomsShipmentValue);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.InBondTypeCode, 2);
		validator.Length(x => x.EntryNumber, 1, 15);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.LocationIdentifier2, 1, 25);
		validator.Length(x => x.CustomsShipmentValue, 2, 8);
		validator.Length(x => x.InBondControlNumber, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
