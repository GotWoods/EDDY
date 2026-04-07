using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._155;

public class L20000__L23000_L23200 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(3)] public NX1_PropertyOrEntityIdentification? PropertyOrEntityIdentification { get; set; }
	[SectionPosition(4)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(5)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(6)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(9)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	[SectionPosition(10)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(11)] public List<AWD_AmountWithDescription> AmountWithDescription { get; set; } = new();
	[SectionPosition(12)] public List<ASO_AssetOwnership> AssetOwnership { get; set; } = new();
	[SectionPosition(13)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(14)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(15)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(16)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000_L23200>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 0, 6);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.CommunicationContactInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AmountWithDescription, 1, 2147483647);
		validator.CollectionSize(x => x.AssetOwnership, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		return validator.Results;
	}
}
