using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._198;

public class LIN1__LAPI__LN1_LPWK {
	[SectionPosition(1)] public PWK_Paperwork Paperwork { get; set; } = new();
	[SectionPosition(2)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(3)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<LIN1__LAPI__LN1__LPWK_LAIN> LAIN {get;set;} = new();
	[SectionPosition(8)] public List<LIN1__LAPI__LN1__LPWK_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(9)] public List<LIN1__LAPI__LN1__LPWK_LFAA> LFAA {get;set;} = new();
	[SectionPosition(10)] public List<LIN1__LAPI__LN1__LPWK_LCDA> LCDA {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1_LPWK>(this);
		validator.Required(x => x.Paperwork);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 4);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.LAIN, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LFAA, 1, 2147483647);
		validator.CollectionSize(x => x.LCDA, 1, 2147483647);
		foreach (var item in LAIN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFAA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCDA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
