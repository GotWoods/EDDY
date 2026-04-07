using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._820;

public class L2000_L2400 {
	[SectionPosition(1)] public RMR_RemittanceAdviceAccountsReceivableOpenItemReference RemittanceAdviceAccountsReceivableOpenItemReference { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(6)] public List<L2000__L2400_L2410> L2410 {get;set;} = new();
	[SectionPosition(7)] public List<L2000__L2400_L2420> L2420 {get;set;} = new();
	[SectionPosition(8)] public List<L2000__L2400_L2430> L2430 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2400>(this);
		validator.Required(x => x.RemittanceAdviceAccountsReceivableOpenItemReference);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.L2410, 1, 2147483647);
		validator.CollectionSize(x => x.L2420, 1, 2147483647);
		validator.CollectionSize(x => x.L2430, 1, 2147483647);
		foreach (var item in L2410) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2420) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2430) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
