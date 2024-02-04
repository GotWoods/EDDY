using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Transportation.v5040._325;

namespace Eddy.x12.DomainModels.Transportation.v5040;

public class Edi325_ConsolidationOfGoodsInContainer {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B12_BeginningSegmentForConsolidationOfGoodsInContainer BeginningSegmentForConsolidationOfGoodsInContainer { get; set; } = new();
	[SectionPosition(3)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(4)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(5)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(6)] public V1_VesselIdentification VesselIdentification { get; set; } = new();
	[SectionPosition(7)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(8)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(9)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(10)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(11)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();

	//Details
	[SectionPosition(12)] public List<LMBL> LMBL {get;set;} = new();
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi325_ConsolidationOfGoodsInContainer>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForConsolidationOfGoodsInContainer);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.Required(x => x.VesselIdentification);
		validator.CollectionSize(x => x.EventDetail, 0, 2);
		validator.CollectionSize(x => x.PortOrTerminal, 1, 4);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LMBL, 1, 999);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
