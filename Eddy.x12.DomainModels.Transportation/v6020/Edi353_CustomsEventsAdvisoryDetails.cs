using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._353;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi353_CustomsEventsAdvisoryDetails {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation? ManifestIdentifyingInformation { get; set; }
	[SectionPosition(3)] public P4_PortInformation? PortInformation { get; set; }
	[SectionPosition(4)] public CM_CargoManifest? CargoManifest { get; set; }
	[SectionPosition(5)] public List<LM15> LM15 {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi353_CustomsEventsAdvisoryDetails>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LM15, 1, 9999);
		foreach (var item in LM15) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
