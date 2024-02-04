using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Transportation.v3050._490;

namespace Eddy.x12.DomainModels.Transportation.v3050;

public class Edi490_RateGroupDefinition {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(4)] public GH_GroupHeader GroupHeader { get; set; } = new();
	[SectionPosition(5)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(6)] public List<TT_TermText> TermText { get; set; } = new();
	[SectionPosition(7)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(8)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(9)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(10)] public List<LPT> LPT {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi490_RateGroupDefinition>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.DocketHeader);
		validator.Required(x => x.GroupHeader);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 8);
		validator.CollectionSize(x => x.TermText, 0, 500);
		validator.CollectionSize(x => x.Geography, 0, 500);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 500);
		validator.CollectionSize(x => x.ProductCommodity, 0, 500);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LPT, 0, 500);
		foreach (var item in LPT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
