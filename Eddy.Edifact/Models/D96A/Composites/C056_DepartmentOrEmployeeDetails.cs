using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C056")]
public class C056_DepartmentOrEmployeeDetails : EdifactComponent
{
	[Position(1)]
	public string DepartmentOrEmployeeIdentification { get; set; }

	[Position(2)]
	public string DepartmentOrEmployee { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C056_DepartmentOrEmployeeDetails>(this);
		validator.Length(x => x.DepartmentOrEmployeeIdentification, 1, 17);
		validator.Length(x => x.DepartmentOrEmployee, 1, 35);
		return validator.Results;
	}
}
