using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._422;

public class LLX_LF9 {
	[SectionPosition(1)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(2)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(3)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LF9_LSCR> LSCR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LF9>(this);
		validator.Required(x => x.OriginStation);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.LSCR, 1, 9999);
		foreach (var item in LSCR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
