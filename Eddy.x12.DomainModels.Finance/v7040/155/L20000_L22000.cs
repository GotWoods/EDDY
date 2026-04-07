using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._155;

public class L20000_L22000 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(5)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(8)] public List<L20000__L22000_L22100> L22100 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000_L22000>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.CommunicationContactInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.L22100, 1, 2147483647);
		foreach (var item in L22100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
