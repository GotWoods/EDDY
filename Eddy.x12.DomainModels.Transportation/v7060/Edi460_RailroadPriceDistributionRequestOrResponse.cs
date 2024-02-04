using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Transportation.v7060._460;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi460_RailroadPriceDistributionRequestOrResponse {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(4)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(5)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(6)] public SS_DocketControlStatus? DocketControlStatus { get; set; }
	[SectionPosition(7)] public SA_StatusAction? StatusAction { get; set; }
	[SectionPosition(8)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(9)] public List<RAB_RateOrMinimumQualifiers> RateOrMinimumQualifiers { get; set; } = new();
	[SectionPosition(10)] public List<LPT> LPT {get;set;} = new();
	[SectionPosition(11)] public List<LSB> LSB {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi460_RailroadPriceDistributionRequestOrResponse>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 8);
		validator.CollectionSize(x => x.ProductCommodity, 0, 200);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 150);
		validator.CollectionSize(x => x.RateOrMinimumQualifiers, 0, 48);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LPT, 0, 50);
		validator.CollectionSize(x => x.LSB, 1, 50);
		foreach (var item in LPT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSB) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
