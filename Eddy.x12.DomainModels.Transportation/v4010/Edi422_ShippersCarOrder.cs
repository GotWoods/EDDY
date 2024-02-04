using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._422;

namespace Eddy.x12.DomainModels.Transportation.v4010;

public class Edi422_ShippersCarOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BCQ_BeginningSegmentForShippersCarOrder BeginningSegmentForShippersCarOrder { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi422_ShippersCarOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShippersCarOrder);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 5);
		validator.CollectionSize(x => x.LLX, 1, 31);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
