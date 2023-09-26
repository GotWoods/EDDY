using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("M21")]
public class M21_SupplementaryInBondInformation : EdiX12Segment
{
	[Position(01)]
	public string CustomsEntryTypeCode { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(05)]
	public string MasterInBondTypeCode { get; set; }

	[Position(06)]
	public string InBondControlNumber { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(08)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(10)]
	public string BillOfLadingWaybillNumber3 { get; set; }

	[Position(11)]
	public string StandardCarrierAlphaCode4 { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode5 { get; set; }

	[Position(13)]
	public decimal? Quantity { get; set; }

	[Position(14)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(15)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M21_SupplementaryInBondInformation>(this);
		validator.Required(x=>x.CustomsEntryTypeCode);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.MasterInBondTypeCode);
		validator.Required(x=>x.InBondControlNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode2, x=>x.BillOfLadingWaybillNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode3, x=>x.BillOfLadingWaybillNumber3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.CustomsEntryTypeCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 25);
		validator.Length(x => x.MasterInBondTypeCode, 1);
		validator.Length(x => x.InBondControlNumber, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber3, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode5, 2, 4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
