using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Transportation.v6030._466;

namespace Eddy.x12.DomainModels.Transportation.v6030;

public class Edi466_RateRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public DK_DocketHeader? DocketHeader { get; set; }
	[SectionPosition(4)] public PR1_PriceRequestParameterList1? PriceRequestParameterList1 { get; set; }
	[SectionPosition(5)] public PR2_PriceRequestParameterList2? PriceRequestParameterList2 { get; set; }
	[SectionPosition(6)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi466_RateRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
