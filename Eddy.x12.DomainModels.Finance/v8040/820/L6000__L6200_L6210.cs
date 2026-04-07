using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L6000__L6200_L6210 {
	[SectionPosition(1)] public EMS_EmploymentPosition EmploymentPosition { get; set; } = new();
	[SectionPosition(2)] public List<ATN_Attendance> Attendance { get; set; } = new();
	[SectionPosition(3)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(4)] public List<PYD_PayrollDeduction> PayrollDeduction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L6000__L6200_L6210>(this);
		validator.Required(x => x.EmploymentPosition);
		validator.CollectionSize(x => x.Attendance, 1, 2147483647);
		validator.CollectionSize(x => x.Income, 1, 2147483647);
		validator.CollectionSize(x => x.PayrollDeduction, 1, 2147483647);
		return validator.Results;
	}
}
