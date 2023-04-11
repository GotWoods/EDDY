using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("DPN")]
public class DPN_DependentInformation : EdiX12Segment
{
	[Position(01)]
	public int? Number { get; set; }

	[Position(02)]
	public string MaritalStatusCode { get; set; }

	[Position(03)]
	public string EmploymentStatusCode { get; set; }

	[Position(04)]
	public int? Number2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DPN_DependentInformation>(this);
		validator.Required(x=>x.Number);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.MaritalStatusCode, 1);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.Number2, 1, 9);
		return validator.Results;
	}
}
