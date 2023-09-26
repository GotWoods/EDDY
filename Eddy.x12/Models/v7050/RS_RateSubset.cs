using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RS_RateSubset>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.Number);
		validator.ARequiresB(x=>x.RateLevelQualifierCode, x=>x.RateLevel);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.RateLevelQualifierCode, 1);
		validator.Length(x => x.RateLevel, 1, 5);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
