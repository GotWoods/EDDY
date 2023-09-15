using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("MIN")]
public class MIN_MinimumDetail : EdiX12Segment
{
	[Position(01)]
	public string LoadingRestriction { get; set; }

	[Position(02)]
	public string LoadingRestriction2 { get; set; }

	[Position(03)]
	public string LoadingRestriction3 { get; set; }

	[Position(04)]
	public string LoadingRestriction4 { get; set; }

	[Position(05)]
	public string LoadingRestriction5 { get; set; }

	[Position(06)]
	public string LoadingRestriction6 { get; set; }

	[Position(07)]
	public string LoadingRestriction7 { get; set; }

	[Position(08)]
	public string LoadingRestriction8 { get; set; }

	[Position(09)]
	public string LoadingRestriction9 { get; set; }

	[Position(10)]
	public string LoadingRestriction10 { get; set; }

	[Position(11)]
	public string LoadingRestriction11 { get; set; }

	[Position(12)]
	public string LoadingRestriction12 { get; set; }

	[Position(13)]
	public string LoadingRestriction13 { get; set; }

	[Position(14)]
	public string LoadingRestriction14 { get; set; }

	[Position(15)]
	public string LoadingRestriction15 { get; set; }

	[Position(16)]
	public string LoadingRestriction16 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIN_MinimumDetail>(this);
		validator.Required(x=>x.LoadingRestriction);
		validator.Length(x => x.LoadingRestriction, 1, 7);
		validator.Length(x => x.LoadingRestriction2, 1, 7);
		validator.Length(x => x.LoadingRestriction3, 1, 7);
		validator.Length(x => x.LoadingRestriction4, 1, 7);
		validator.Length(x => x.LoadingRestriction5, 1, 7);
		validator.Length(x => x.LoadingRestriction6, 1, 7);
		validator.Length(x => x.LoadingRestriction7, 1, 7);
		validator.Length(x => x.LoadingRestriction8, 1, 7);
		validator.Length(x => x.LoadingRestriction9, 1, 7);
		validator.Length(x => x.LoadingRestriction10, 1, 7);
		validator.Length(x => x.LoadingRestriction11, 1, 7);
		validator.Length(x => x.LoadingRestriction12, 1, 7);
		validator.Length(x => x.LoadingRestriction13, 1, 7);
		validator.Length(x => x.LoadingRestriction14, 1, 7);
		validator.Length(x => x.LoadingRestriction15, 1, 7);
		validator.Length(x => x.LoadingRestriction16, 1, 7);
		return validator.Results;
	}
}
