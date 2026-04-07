using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._135;

public class LENT {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public ENR_SchoolEnrollmentInformation? SchoolEnrollmentInformation { get; set; }
	[SectionPosition(4)] public FNA_FinancialStatusInformation? FinancialStatusInformation { get; set; }
	[SectionPosition(5)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(6)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(7)] public List<SCT_SchoolType> SchoolType { get; set; } = new();
	[SectionPosition(8)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(9)] public Y6_Authentication? Authentication { get; set; }
	[SectionPosition(10)] public List<IDB_IndebtednessForStudentLoans> IndebtednessForStudentLoans { get; set; } = new();
	[SectionPosition(11)] public List<LENT_LN1> LN1 {get;set;} = new();
	[SectionPosition(12)] public List<LENT_LPLI> LPLI {get;set;} = new();
	[SectionPosition(13)] public List<LENT_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(14)] public List<LENT_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 15);
		validator.CollectionSize(x => x.Measurements, 0, 2);
		validator.CollectionSize(x => x.SchoolType, 0, 8);
		validator.CollectionSize(x => x.IndebtednessForStudentLoans, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 2);
		validator.CollectionSize(x => x.LPLI, 0, 10);
		validator.CollectionSize(x => x.LIN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPLI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
