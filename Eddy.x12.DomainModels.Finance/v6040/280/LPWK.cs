using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._280;

public class LPWK {
	[SectionPosition(1)] public PWK_Paperwork Paperwork { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<LPWK_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(8)] public List<LPWK_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(9)] public List<LPWK_LEFI> LEFI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPWK>(this);
		validator.Required(x => x.Paperwork);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.LIN1, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LEFI, 1, 2147483647);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LEFI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
