using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._132;

public class LHL_LEMS {
	[SectionPosition(1)] public EMS_EmploymentPosition EmploymentPosition { get; set; } = new();
	[SectionPosition(2)] public List<ISI_InstitutionalStaffInformation> InstitutionalStaffInformation { get; set; } = new();
	[SectionPosition(3)] public ESI_EmploymentStatusInformation? EmploymentStatusInformation { get; set; }
	[SectionPosition(4)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(8)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(9)] public List<ELV_EmployeeLeaveSummary> EmployeeLeaveSummary { get; set; } = new();
	[SectionPosition(10)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(11)] public CN1_ContractInformation? ContractInformation { get; set; }
	[SectionPosition(12)] public CON_ContractNumberDetail? ContractNumberDetail { get; set; }
	[SectionPosition(13)] public List<LHL__LEMS_LN9> LN9 {get;set;} = new();
	[SectionPosition(14)] public List<LHL__LEMS_LN1> LN1 {get;set;} = new();
	[SectionPosition(15)] public List<LHL__LEMS_LSES> LSES {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LEMS>(this);
		validator.Required(x => x.EmploymentPosition);
		validator.CollectionSize(x => x.InstitutionalStaffInformation, 1, 2147483647);
		validator.CollectionSize(x => x.IndustryCode, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.EmployeeLeaveSummary, 0, 15);
		validator.CollectionSize(x => x.Income, 0, 25);
		validator.CollectionSize(x => x.LN9, 1, 2147483647);
		validator.CollectionSize(x => x.LSES, 1, 2147483647);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSES) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
