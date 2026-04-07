using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L8000 {
	[SectionPosition(1)] public INS_InsuredBenefit InsuredBenefit { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<L8000_L8100> L8100 {get;set;} = new();
	[SectionPosition(8)] public List<L8000_L8200> L8200 {get;set;} = new();
	[SectionPosition(9)] public List<L8000_L8300> L8300 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L8000>(this);
		validator.Required(x => x.InsuredBenefit);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.L8100, 1, 2147483647);
		validator.CollectionSize(x => x.L8200, 1, 2147483647);
		validator.CollectionSize(x => x.L8300, 1, 2147483647);
		foreach (var item in L8100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L8200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L8300) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
