using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._222;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi222_CartageWorkAssignment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public SCN_BeginningSegmentForCartageWorkAssignment BeginningSegmentForCartageWorkAssignment { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(7)] public List<L2000> L2000 {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi222_CartageWorkAssignment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCartageWorkAssignment);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 5);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L2000, 1, 999);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
