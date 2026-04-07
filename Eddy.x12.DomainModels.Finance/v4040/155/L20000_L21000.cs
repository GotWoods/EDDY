using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._155;

public class L20000_L21000 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000_L21000>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 0, 3);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		return validator.Results;
	}
}
