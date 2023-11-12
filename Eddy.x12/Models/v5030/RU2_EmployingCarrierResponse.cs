using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("RU2")]
public class RU2_EmployingCarrierResponse : EdiX12Segment
{
	[Position(01)]
	public string RailRetirementActivityCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string EmploymentStatusCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string FrequencyCode { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string Date3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RU2_EmployingCarrierResponse>(this);
		validator.Required(x=>x.RailRetirementActivityCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Date, x=>x.EmploymentStatusCode);
		validator.Length(x => x.RailRetirementActivityCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		return validator.Results;
	}
}
