using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._820;

public class L5000_L5100 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public G53_MaintenanceType? MaintenanceType { get; set; }
	[SectionPosition(4)] public List<L5000__L5100_L5110> L5110 {get;set;} = new();
	[SectionPosition(5)] public List<L5000__L5100_L5120> L5120 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L5000_L5100>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.L5110, 1, 2147483647);
		validator.CollectionSize(x => x.L5120, 1, 2147483647);
		foreach (var item in L5110) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L5120) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
