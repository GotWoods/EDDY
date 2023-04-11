using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G18")]
public class G18_StoreCategorySize : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public decimal? Length { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G18_StoreCategorySize>(this);
		validator.OnlyOneOf(x=>x.EntityIdentifierCode, x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
