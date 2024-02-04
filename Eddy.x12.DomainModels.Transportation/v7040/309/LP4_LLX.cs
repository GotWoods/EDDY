using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._309;

public class LP4_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public M13_ManifestAmendmentDetails? ManifestAmendmentDetails { get; set; }
	[SectionPosition(3)] public M11_ManifestBillOfLadingDetails? ManifestBillOfLadingDetails { get; set; }
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<LP4__LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LP4__LLX_LM12> LM12 {get;set;} = new();
	[SectionPosition(7)] public List<LP4__LLX_LVID> LVID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 999);
		validator.CollectionSize(x => x.LN1, 0, 25);
		validator.CollectionSize(x => x.LVID, 0, 999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LM12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
