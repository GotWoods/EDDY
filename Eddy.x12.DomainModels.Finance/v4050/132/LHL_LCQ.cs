using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._132;

public class LHL_LCQ {
	[SectionPosition(1)] public CQ_CredentialsAndQualifications CredentialsAndQualifications { get; set; } = new();
	[SectionPosition(2)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<ISI_InstitutionalStaffInformation> InstitutionalStaffInformation { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<LHL__LCQ_LDEG> LDEG {get;set;} = new();
	[SectionPosition(8)] public List<LHL__LCQ_LCRS> LCRS {get;set;} = new();
	[SectionPosition(9)] public List<LHL__LCQ_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LCQ>(this);
		validator.Required(x => x.CredentialsAndQualifications);
		validator.CollectionSize(x => x.FieldOfStudy, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.InstitutionalStaffInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.LDEG, 0, 5);
		validator.CollectionSize(x => x.LCRS, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCRS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
