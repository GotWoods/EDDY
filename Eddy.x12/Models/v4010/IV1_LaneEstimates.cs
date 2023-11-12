using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("IV1")]
public class IV1_LaneEstimates : EdiX12Segment
{
	[Position(01)]
	public string VolumeUnitQualifier { get; set; }

	[Position(02)]
	public decimal? Volume { get; set; }

	[Position(03)]
	public int? Number { get; set; }

	[Position(04)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(05)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IV1_LaneEstimates>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.ARequiresB(x=>x.UnitOfTimePeriodOrInterval, x=>x.Volume);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		return validator.Results;
	}
}
