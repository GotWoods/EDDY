using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;
using Eddy.x12.DomainModels.Transportation.v6010._486;

namespace Eddy.x12.DomainModels.Transportation.v6010;

public class Edi486_RateDocketExpiration {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public DR_DocketRange DocketRange { get; set; } = new();
	[SectionPosition(4)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(5)] public SA_StatusAction StatusAction { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi486_RateDocketExpiration>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.DocketRange);
		validator.Required(x => x.StatusAction);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
