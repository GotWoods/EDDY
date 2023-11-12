using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("RD")]
public class RD_RateData : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string RateApplicationTypeCode { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string ChangeTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RD_RateData>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.RateApplicationTypeCode);
		validator.Required(x=>x.FreightRate);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.RateApplicationTypeCode, 1);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.ChangeTypeCode, 1);
		return validator.Results;
	}
}
