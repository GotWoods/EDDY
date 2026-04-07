using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._198;

public class LIN1__LAPI_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(7)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(8)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(9)] public List<LIN1__LAPI__LN1_LPWK> LPWK {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.Income, 0, 5);
		validator.CollectionSize(x => x.LPWK, 1, 2147483647);
		foreach (var item in LPWK) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
