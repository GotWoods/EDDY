using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("SV")]
public class SV_ServiceDescription : EdiX12Segment
{
	[Position(01)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(02)]
	public string ServiceStandard { get; set; }

	[Position(03)]
	public string ServiceStandard2 { get; set; }

	[Position(04)]
	public string TypeOfServiceOfferedCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV_ServiceDescription>(this);
		validator.ARequiresB(x=>x.ServiceStandard, x=>x.UnitOfTimePeriodOrIntervalCode);
		validator.ARequiresB(x=>x.ServiceStandard2, x=>x.UnitOfTimePeriodOrIntervalCode);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.ServiceStandard, 1, 4);
		validator.Length(x => x.ServiceStandard2, 1, 4);
		validator.Length(x => x.TypeOfServiceOfferedCode, 1);
		return validator.Results;
	}
}
