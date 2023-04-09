using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CD2")]
public class CD2_MultiValuedCharacteristics : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string MedicalCodeValue { get; set; }

	[Position(04)]
	public string MedicalCodeValue2 { get; set; }

	[Position(05)]
	public string MedicalCodeValue3 { get; set; }

	[Position(06)]
	public string MedicalCodeValue4 { get; set; }

	[Position(07)]
	public string MedicalCodeValue5 { get; set; }

	[Position(08)]
	public string MedicalCodeValue6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CD2_MultiValuedCharacteristics>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.MedicalCodeValue);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.MedicalCodeValue, 1, 15);
		validator.Length(x => x.MedicalCodeValue2, 1, 15);
		validator.Length(x => x.MedicalCodeValue3, 1, 15);
		validator.Length(x => x.MedicalCodeValue4, 1, 15);
		validator.Length(x => x.MedicalCodeValue5, 1, 15);
		validator.Length(x => x.MedicalCodeValue6, 1, 15);
		return validator.Results;
	}
}
