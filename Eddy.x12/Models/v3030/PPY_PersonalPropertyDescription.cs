using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PPY")]
public class PPY_PersonalPropertyDescription : EdiX12Segment
{
	[Position(01)]
	public string TypeOfPersonalPropertyCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string FreeFormMessage { get; set; }

	[Position(05)]
	public string FreeFormMessage2 { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PPY_PersonalPropertyDescription>(this);
		validator.Required(x=>x.TypeOfPersonalPropertyCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.TypeOfPersonalPropertyCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.FreeFormMessage2, 1, 30);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
