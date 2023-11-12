using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("RU1")]
public class RU1_RetirementBoardDetail : EdiX12Segment
{
	[Position(01)]
	public string RailRetirementActivityCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string EmploymentCode { get; set; }

	[Position(07)]
	public string UnemployedReasonCode { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string ClaimProfile { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RU1_RetirementBoardDetail>(this);
		validator.Required(x=>x.RailRetirementActivityCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Name);
		validator.Length(x => x.RailRetirementActivityCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EmploymentCode, 1);
		validator.Length(x => x.UnemployedReasonCode, 1);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ClaimProfile, 14);
		return validator.Results;
	}
}
