using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._849;

public class LCON {
	[SectionPosition(1)] public CON_ContractNumberDetail ContractNumberDetail { get; set; } = new();
	[SectionPosition(2)] public List<AAA_RequestValidation> RequestValidation { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<LCON_LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LCON_LPAD> LPAD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCON>(this);
		validator.Required(x => x.ContractNumberDetail);
		validator.CollectionSize(x => x.RequestValidation, 0, 10);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 50);
		validator.CollectionSize(x => x.LPAD, 0, 1000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPAD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
