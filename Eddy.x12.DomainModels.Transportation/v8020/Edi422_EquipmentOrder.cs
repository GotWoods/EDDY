using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._422;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi422_EquipmentOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BCQ_BeginningSegmentForShippersCarOrder BeginningSegmentForShippersCarOrder { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(5)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(9)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi422_EquipmentOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShippersCarOrder);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 3);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 0, 3);
		validator.CollectionSize(x => x.QuantityInformation, 0, 3);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 5);
		validator.CollectionSize(x => x.LLX, 1, 31);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
