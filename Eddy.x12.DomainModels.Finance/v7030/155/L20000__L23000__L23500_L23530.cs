using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._155;

public class L20000__L23000__L23500_L23530 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(7)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public ITC_InformationTypeAndCommentResults? InformationTypeAndCommentResults { get; set; }
	[SectionPosition(10)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(11)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(12)] public List<AWD_AmountWithDescription> AmountWithDescription { get; set; } = new();
	[SectionPosition(13)] public List<L20000__L23000__L23500__L23530_L23531> L23531 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500_L23530>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 0, 6);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.CommunicationContactInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.AmountWithDescription, 1, 2147483647);
		validator.CollectionSize(x => x.L23531, 1, 2147483647);
		foreach (var item in L23531) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
