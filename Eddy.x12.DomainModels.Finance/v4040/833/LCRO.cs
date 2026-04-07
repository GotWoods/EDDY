using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._833;

public class LCRO {
	[SectionPosition(1)] public CRO_CreditReportOrderDetails CreditReportOrderDetails { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<K2_AdministrativeMessage> AdministrativeMessage { get; set; } = new();
	[SectionPosition(5)] public LRQ_MortgageCharacteristicsRequested? MortgageCharacteristicsRequested { get; set; }
	[SectionPosition(6)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(7)] public List<LCRO_LN1> LN1 {get;set;} = new();
	[SectionPosition(8)] public List<LCRO_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(9)] public List<LCRO_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO>(this);
		validator.Required(x => x.CreditReportOrderDetails);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.AdministrativeMessage, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 20);
		validator.CollectionSize(x => x.LNX1, 0, 20);
		validator.CollectionSize(x => x.LLX, 1, 2);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
