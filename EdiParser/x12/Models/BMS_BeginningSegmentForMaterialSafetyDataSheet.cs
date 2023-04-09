using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string RevisionValue { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string RevisionValue2 { get; set; }

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
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.RevisionValue, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.RevisionValue2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
