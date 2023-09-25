using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BMS")]
public class BMS_BeginningSegmentForMaterialSafetyDataSheet : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string LanguageCode { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public int? RevisionNumber { get; set; }

	[Position(06)]
	public string ReferenceNumber2 { get; set; }

	[Position(07)]
	public int? RevisionNumber2 { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	[Position(09)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BMS_BeginningSegmentForMaterialSafetyDataSheet>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.RevisionNumber, 1, 4);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.RevisionNumber2, 1, 4);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2);
		return validator.Results;
	}
}
