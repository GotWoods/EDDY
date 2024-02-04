using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._490;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi490_RateGroupDefinition {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(3)] public List<PRI_ExternalReferenceIdentifier> ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(4)] public GH_GroupHeader GroupHeader { get; set; } = new();
	[SectionPosition(5)] public List<PRI_ExternalReferenceIdentifier> ExternalReferenceIdentifier2 { get; set; } = new();
	[SectionPosition(6)] public List<TT_TermText> TermText { get; set; } = new();
	[SectionPosition(7)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(8)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(9)] public List<L0300> L0300 {get;set;} = new();
	[SectionPosition(10)] public List<L0400> L0400 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi490_RateGroupDefinition>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.ExternalReferenceIdentifier, 1, 8);
		validator.Required(x => x.GroupHeader);
		validator.CollectionSize(x => x.ExternalReferenceIdentifier2, 0, 1000);
		validator.CollectionSize(x => x.TermText, 0, 500);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 500);
		validator.CollectionSize(x => x.L0200, 0, 500);
		validator.CollectionSize(x => x.L0300, 0, 500);
		validator.CollectionSize(x => x.L0400, 0, 500);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
