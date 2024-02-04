using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._353;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi353_USCustomsEventsAdvisoryDetails {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public P4_USPortInformation USPortInformation { get; set; } = new();
	[SectionPosition(4)] public List<M15_USCustomsEventsAdvisoryDetails> USCustomsEventsAdvisoryDetails { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi353_USCustomsEventsAdvisoryDetails>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.Required(x => x.USPortInformation);
		validator.CollectionSize(x => x.USCustomsEventsAdvisoryDetails, 1, 9999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
