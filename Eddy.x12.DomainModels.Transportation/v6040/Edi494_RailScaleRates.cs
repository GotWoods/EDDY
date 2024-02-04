using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Transportation.v6040._494;

namespace Eddy.x12.DomainModels.Transportation.v6040;

public class Edi494_RailScaleRates {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public REN_RateRequestInformation RateRequestInformation { get; set; } = new();
	[SectionPosition(3)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(4)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(5)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(6)] public SS_DocketControlStatus? DocketControlStatus { get; set; }
	[SectionPosition(7)] public SA_StatusAction StatusAction { get; set; } = new();
	[SectionPosition(8)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(9)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(10)] public List<RAB_RateOrMinimumQualifiers> RateOrMinimumQualifiers { get; set; } = new();
	[SectionPosition(11)] public List<PT_Patron> Patron { get; set; } = new();
	[SectionPosition(12)] public List<LR9> LR9 {get;set;} = new();
	[SectionPosition(13)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi494_RailScaleRates>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.RateRequestInformation);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 1, 25);
		validator.CollectionSize(x => x.ProductCommodity, 0, 200);
		validator.Required(x => x.StatusAction);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 150);
		validator.CollectionSize(x => x.Geography, 0, 150);
		validator.CollectionSize(x => x.RateOrMinimumQualifiers, 0, 12);
		validator.CollectionSize(x => x.Patron, 0, 50);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR9, 0, 10);
		foreach (var item in LR9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
