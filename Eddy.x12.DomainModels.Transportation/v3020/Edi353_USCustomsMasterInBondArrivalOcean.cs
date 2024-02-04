using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._353;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi353_USCustomsMasterInBondArrivalOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public P4_PortOfDischargeInformation PortOfDischargeInformation { get; set; } = new();
	[SectionPosition(4)] public List<M15_MasterInBondArrivalDetails> MasterInBondArrivalDetails { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi353_USCustomsMasterInBondArrivalOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.Required(x => x.PortOfDischargeInformation);
		validator.CollectionSize(x => x.MasterInBondArrivalDetails, 1, 999);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
