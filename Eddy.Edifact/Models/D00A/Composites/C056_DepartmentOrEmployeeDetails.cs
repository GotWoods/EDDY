using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C056")]
public class C056_DepartmentOrEmployeeDetails : EdifactComponent
{
	[Position(1)]
	public string DepartmentOrEmployeeNameCode { get; set; }

	[Position(2)]
	public string DepartmentOrEmployeeName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C056_DepartmentOrEmployeeDetails>(this);
		validator.Length(x => x.DepartmentOrEmployeeNameCode, 1, 17);
		validator.Length(x => x.DepartmentOrEmployeeName, 1, 35);
		return validator.Results;
	}
}
