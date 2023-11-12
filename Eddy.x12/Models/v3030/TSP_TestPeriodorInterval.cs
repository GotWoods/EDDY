using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("TSP")]
public class TSP_TestPeriodOrInterval : EdiX12Segment
{
	[Position(01)]
	public string TestPeriodOrIntervalQualifier { get; set; }

	[Position(02)]
	public string AssignedIdentification { get; set; }

	[Position(03)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(04)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TSP_TestPeriodOrInterval>(this);
		validator.Required(x=>x.TestPeriodOrIntervalQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrInterval);
		validator.Length(x => x.TestPeriodOrIntervalQualifier, 2);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		return validator.Results;
	}
}
