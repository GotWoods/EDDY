using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RB")]
public class RB_RateMinimumDetail : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string RateApplicationTypeCode { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string MinimumWeightLogic { get; set; }

	[Position(05)]
	public string LoadingRestriction { get; set; }

	[Position(06)]
	public string LoadingRestriction2 { get; set; }

	[Position(07)]
	public int? Percent { get; set; }

	[Position(08)]
	public string ChangeTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RB_RateMinimumDetail>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.RateApplicationTypeCode);
		validator.Required(x=>x.FreightRate);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.RateApplicationTypeCode, 1);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.MinimumWeightLogic, 1, 2);
		validator.Length(x => x.LoadingRestriction, 1, 7);
		validator.Length(x => x.LoadingRestriction2, 1, 7);
		validator.Length(x => x.Percent, 1, 3);
		validator.Length(x => x.ChangeTypeCode, 1);
		return validator.Results;
	}
}
