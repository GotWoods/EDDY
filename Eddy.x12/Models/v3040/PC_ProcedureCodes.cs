using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PC")]
public class PC_MedicalProceduresCode : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string MedicalCodeValue { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string MedicalCodeValue2 { get; set; }

	[Position(06)]
	public string DateTimePeriod2 { get; set; }

	[Position(07)]
	public string MedicalCodeValue3 { get; set; }

	[Position(08)]
	public string DateTimePeriod3 { get; set; }

	[Position(09)]
	public string MedicalCodeValue4 { get; set; }

	[Position(10)]
	public string DateTimePeriod4 { get; set; }

	[Position(11)]
	public string MedicalCodeValue5 { get; set; }

	[Position(12)]
	public string DateTimePeriod5 { get; set; }

	[Position(13)]
	public string MedicalCodeValue6 { get; set; }

	[Position(14)]
	public string DateTimePeriod6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PC_MedicalProceduresCode>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue, x=>x.DateTimePeriod);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod, x=>x.DateTimePeriod2, x=>x.DateTimePeriod3, x=>x.DateTimePeriod4, x=>x.DateTimePeriod5, x=>x.DateTimePeriod6);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue2, x=>x.DateTimePeriod2);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue3, x=>x.DateTimePeriod3);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue4, x=>x.DateTimePeriod4);
		validator.ARequiresB(x=>x.DateTimePeriod4, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue5, x=>x.DateTimePeriod5);
		validator.ARequiresB(x=>x.DateTimePeriod5, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MedicalCodeValue6, x=>x.DateTimePeriod6);
		validator.ARequiresB(x=>x.DateTimePeriod6, x=>x.DateTimePeriodFormatQualifier);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.MedicalCodeValue, 1, 15);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.MedicalCodeValue2, 1, 15);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.MedicalCodeValue3, 1, 15);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.MedicalCodeValue4, 1, 15);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.MedicalCodeValue5, 1, 15);
		validator.Length(x => x.DateTimePeriod5, 1, 35);
		validator.Length(x => x.MedicalCodeValue6, 1, 15);
		validator.Length(x => x.DateTimePeriod6, 1, 35);
		return validator.Results;
	}
}
