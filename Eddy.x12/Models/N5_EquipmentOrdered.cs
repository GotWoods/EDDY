using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("N5")]
public class N5_EquipmentOrdered : EdiX12Segment
{
	[Position(01)]
	public int? EquipmentLength { get; set; }

	[Position(02)]
	public int? WeightCapacity { get; set; }

	[Position(03)]
	public int? CubicCapacity { get; set; }

	[Position(04)]
	public string CarTypeCode { get; set; }

	[Position(05)]
	public string MetricQualifier { get; set; }

	[Position(06)]
	public decimal? Height { get; set; }

	[Position(07)]
	public string LadingPercentage { get; set; }

	[Position(08)]
	public string LadingPercentQualifier { get; set; }

	[Position(09)]
	public string EquipmentDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N5_EquipmentOrdered>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LadingPercentage, x=>x.LadingPercentQualifier);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.WeightCapacity, 2, 3);
		validator.Length(x => x.CubicCapacity, 2, 5);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.MetricQualifier, 1);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.LadingPercentage, 2, 4);
		validator.Length(x => x.LadingPercentQualifier, 1);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		return validator.Results;
	}
}
