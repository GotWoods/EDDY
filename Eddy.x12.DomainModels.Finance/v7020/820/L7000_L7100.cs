using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._820;

public class L7000_L7100 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<L7000__L7100_L7110> L7110 {get;set;} = new();
	[SectionPosition(3)] public List<L7000__L7100_L7120> L7120 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000_L7100>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.L7110, 1, 2147483647);
		foreach (var item in L7110) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L7120) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
