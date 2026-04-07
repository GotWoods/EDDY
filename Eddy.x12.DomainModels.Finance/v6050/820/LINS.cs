using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._820;

public class LINS {
	[SectionPosition(1)] public INS_InsuredBenefit InsuredBenefit { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<LINS_LADX> LADX {get;set;} = new();
	[SectionPosition(8)] public List<LINS_LHD> LHD {get;set;} = new();
	[SectionPosition(9)] public List<LINS_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LINS>(this);
		validator.Required(x => x.InsuredBenefit);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		validator.CollectionSize(x => x.LHD, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LHD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
