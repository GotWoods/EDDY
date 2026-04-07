using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._155;

public class L20000__L23000__L23500_L23540 {
	[SectionPosition(1)] public CED_AdministrationOfJusticeEventDescription AdministrationOfJusticeEventDescription { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(4)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(5)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(6)] public List<L20000__L23000__L23500__L23540_L23541> L23541 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500_L23540>(this);
		validator.Required(x => x.AdministrationOfJusticeEventDescription);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.L23541, 1, 2147483647);
		foreach (var item in L23541) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
