using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._475;

public class LR9 {
	[SectionPosition(1)] public R9_RouteCodeIdentification RouteCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<RDD_RouteDescriptionDetail> RouteDescriptionDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR9>(this);
		validator.Required(x => x.RouteCodeIdentification);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.CollectionSize(x => x.RouteDescriptionDetail, 0, 5);
		return validator.Results;
	}
}
