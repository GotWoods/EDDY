using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._844;

public class LCON {
	[SectionPosition(1)] public CON_ContractNumberDetail ContractNumberDetail { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<LCON_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LCON_LPAD> LPAD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCON>(this);
		validator.Required(x => x.ContractNumberDetail);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LPAD, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPAD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
