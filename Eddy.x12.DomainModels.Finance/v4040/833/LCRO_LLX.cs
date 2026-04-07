using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._833;

public class LCRO_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(5)] public List<PPY_PersonalPropertyDescription> PersonalPropertyDescription { get; set; } = new();
	[SectionPosition(6)] public List<CAI_CivilActionIncome> CivilActionIncome { get; set; } = new();
	[SectionPosition(7)] public List<CIV_CivilActionLiability> CivilActionLiability { get; set; } = new();
	[SectionPosition(8)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(9)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(10)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(11)] public List<LCRO__LLX_LAMT> LAMT {get;set;} = new();
	[SectionPosition(12)] public List<LCRO__LLX_LREA> LREA {get;set;} = new();
	[SectionPosition(13)] public List<LCRO__LLX_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(14)] public List<LCRO__LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(15)] public List<LCRO__LLX_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.Income, 0, 10);
		validator.CollectionSize(x => x.PersonalPropertyDescription, 0, 10);
		validator.CollectionSize(x => x.CivilActionIncome, 0, 20);
		validator.CollectionSize(x => x.CivilActionLiability, 0, 20);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 12);
		validator.CollectionSize(x => x.Quantity, 0, 20);
		validator.CollectionSize(x => x.LAMT, 0, 10);
		validator.CollectionSize(x => x.LREA, 0, 20);
		validator.CollectionSize(x => x.LIN1, 1, 30);
		validator.CollectionSize(x => x.LNX1, 1, 10);
		validator.CollectionSize(x => x.LN1, 0, 500);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
