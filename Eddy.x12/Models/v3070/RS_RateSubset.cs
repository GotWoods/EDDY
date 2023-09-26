using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("RS")]
public class RS_RateSubset : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	[Position(03)]
	public string RateLevelQualifierCode { get; set; }

	[Position(04)]
	public string RateLevel { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public int? Century { get; set; }

	[Position(08)]
	public int? Century2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RS_RateSubset>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.Number);
		validator.ARequiresB(x=>x.RateLevelQualifierCode, x=>x.RateLevel);
		validator.ARequiresB(x=>x.Century, x=>x.Date);
		validator.ARequiresB(x=>x.Century2, x=>x.Date2);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.RateLevelQualifierCode, 1);
		validator.Length(x => x.RateLevel, 1, 5);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.Century2, 2);
		return validator.Results;
	}
}
