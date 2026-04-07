using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._133;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public List<SCT_SchoolType> SchoolType { get; set; } = new();
	[SectionPosition(3)] public List<OPX_PlacementCriteria> PlacementCriteria { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<DEG_DegreeRecord> DegreeRecord { get; set; } = new();
	[SectionPosition(6)] public List<ISI_InstitutionalStaffInformation> InstitutionalStaffInformation { get; set; } = new();
	[SectionPosition(7)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(8)] public List<EDF_EducationalFeeInformation> EducationalFeeInformation { get; set; } = new();
	[SectionPosition(9)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(10)] public List<LHL_LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<LHL_LYNQ> LYNQ {get;set;} = new();
	[SectionPosition(12)] public List<LHL_LFOS> LFOS {get;set;} = new();
	[SectionPosition(13)] public List<LHL_LSP> LSP {get;set;} = new();
	[SectionPosition(14)] public List<LHL_LSLA> LSLA {get;set;} = new();
	[SectionPosition(15)] public List<LHL_LENM> LENM {get;set;} = new();
	[SectionPosition(16)] public List<LHL_LATV> LATV {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.SchoolType, 1, 2147483647);
		validator.CollectionSize(x => x.PlacementCriteria, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DegreeRecord, 1, 2147483647);
		validator.CollectionSize(x => x.InstitutionalStaffInformation, 1, 2147483647);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.EducationalFeeInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LYNQ, 1, 2147483647);
		validator.CollectionSize(x => x.LFOS, 1, 2147483647);
		validator.CollectionSize(x => x.LSP, 1, 2147483647);
		validator.CollectionSize(x => x.LSLA, 1, 2147483647);
		validator.CollectionSize(x => x.LENM, 1, 2147483647);
		validator.CollectionSize(x => x.LATV, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LYNQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFOS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSLA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LENM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LATV) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
