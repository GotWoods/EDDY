using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C526")]
public class C526_FrequencyDetails : EdifactComponent
{
	[Position(1)]
	public string FrequencyCodeQualifier { get; set; }

	[Position(2)]
	public string FrequencyRate { get; set; }

	[Position(3)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C526_FrequencyDetails>(this);
		validator.Required(x=>x.FrequencyCodeQualifier);
		validator.Length(x => x.FrequencyCodeQualifier, 1, 3);
		validator.Length(x => x.FrequencyRate, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		return validator.Results;
	}
}
