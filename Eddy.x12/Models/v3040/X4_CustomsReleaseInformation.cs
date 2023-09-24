using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("X4")]
public class X4_CustomsReleaseInformation : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string EntryTypeCode { get; set; }

	[Position(04)]
	public string EntryNumber { get; set; }

	[Position(05)]
	public string ReleaseIssueDate { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string DispositionCode { get; set; }

	[Position(08)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(11)]
	public string EquipmentInitial { get; set; }

	[Position(12)]
	public string EquipmentNumber { get; set; }

	[Position(13)]
	public string LocationIdentifier { get; set; }

	[Position(14)]
	public string LocationIdentifier2 { get; set; }

	[Position(15)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(16)]
	public string ReferenceNumber { get; set; }

	[Position(17)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X4_CustomsReleaseInformation>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ReleaseIssueDate);
		validator.Required(x=>x.DispositionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.AtLeastOneIsRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.EntryTypeCode, 2);
		validator.Length(x => x.EntryNumber, 1, 15);
		validator.Length(x => x.ReleaseIssueDate, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.DispositionCode, 2);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
