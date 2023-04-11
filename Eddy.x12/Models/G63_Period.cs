using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G63")]
public class G63_Period : EdiX12Segment
{
	[Position(01)]
	public string TimePeriodQualifier { get; set; }

	[Position(02)]
	public int? NumberOfPeriods { get; set; }

	[Position(03)]
	public string TariffApplicationCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G63_Period>(this);
		validator.Required(x=>x.TimePeriodQualifier);
		validator.Required(x=>x.NumberOfPeriods);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
