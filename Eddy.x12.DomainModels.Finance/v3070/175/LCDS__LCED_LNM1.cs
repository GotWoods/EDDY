using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._175;

public class LCDS__LCED_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<SPI_SpecificationIdentifier> SpecificationIdentifier { get; set; } = new();
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(10)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(11)] public List<LCDS__LCED__LNM1_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS__LCED_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.SpecificationIdentifier, 0, 2);
		validator.CollectionSize(x => x.AdditionalNameInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AddressInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 0, 3);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
