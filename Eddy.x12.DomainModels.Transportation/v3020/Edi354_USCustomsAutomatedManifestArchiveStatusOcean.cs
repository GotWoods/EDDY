using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._354;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi354_USCustomsAutomatedManifestArchiveStatusOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public P4_PortOfDischargeInformation PortOfDischargeInformation { get; set; } = new();
	[SectionPosition(4)] public X01_AutomatedManifestArchiveStatusDetails AutomatedManifestArchiveStatusDetails { get; set; } = new();
	[SectionPosition(5)] public List<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails> AutomatedManifestBillsEligibleOverdueArchiveDetails { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi354_USCustomsAutomatedManifestArchiveStatusOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.Required(x => x.PortOfDischargeInformation);
		validator.Required(x => x.AutomatedManifestArchiveStatusDetails);
		validator.CollectionSize(x => x.AutomatedManifestBillsEligibleOverdueArchiveDetails, 0, 9999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
