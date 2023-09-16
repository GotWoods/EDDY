using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("SRT")]
public class SRT_ScaleRateHeader : EdiX12Segment
{
	[Position(01)]
	public string ChangeTypeCode { get; set; }

	[Position(02)]
	public string RouteCode { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public string RateValueQualifier2 { get; set; }

	[Position(05)]
	public string RateApplicationTypeCode { get; set; }

	[Position(06)]
	public string Scale { get; set; }

	[Position(07)]
	public string Scale2 { get; set; }

	[Position(08)]
	public string MinimumWeightLogic { get; set; }

	[Position(09)]
	public string LoadingRestriction { get; set; }

	[Position(10)]
	public string LoadingRestriction2 { get; set; }

	[Position(11)]
	public int? PercentIntegerFormat { get; set; }

	[Position(12)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(13)]
	public string SpecialChargeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SRT_ScaleRateHeader>(this);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Required(x=>x.RateValueQualifier);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.RateApplicationTypeCode, 1);
		validator.Length(x => x.Scale, 1, 10);
		validator.Length(x => x.Scale2, 1, 10);
		validator.Length(x => x.MinimumWeightLogic, 1, 2);
		validator.Length(x => x.LoadingRestriction, 1, 7);
		validator.Length(x => x.LoadingRestriction2, 1, 7);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		return validator.Results;
	}
}
