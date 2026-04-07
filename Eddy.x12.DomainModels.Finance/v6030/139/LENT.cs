using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._139;

public class LENT {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<IDB_IndebtednessForStudentLoans> IndebtednessForStudentLoans { get; set; } = new();
	[SectionPosition(4)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 5);
		validator.CollectionSize(x => x.IndebtednessForStudentLoans, 0, 10);
		return validator.Results;
	}
}
