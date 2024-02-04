using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._309;

public class LP4_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public M13_ManifestAmendmentDetails? ManifestAmendmentDetails { get; set; }
	[SectionPosition(3)] public M11_ManifestBillOfLadingDetails ManifestBillOfLadingDetails { get; set; } = new();
	[SectionPosition(4)] public LS_LoopHeader LoopHeader { get; set; } = new();
	[SectionPosition(5)] public List<LP4__LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public LE_LoopTrailer LoopTrailer { get; set; } = new();
	[SectionPosition(7)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(8)] public LS_LoopHeader LoopHeader2 { get; set; } = new();
	[SectionPosition(9)] public List<LP4__LLX_LVID> LVID {get;set;} = new();
	[SectionPosition(10)] public LE_LoopTrailer LoopTrailer2 { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.Required(x => x.ManifestBillOfLadingDetails);
		validator.Required(x => x.LoopHeader);
		validator.Required(x => x.LoopTrailer);
		validator.Required(x => x.LoopHeader2);
		validator.Required(x => x.LoopTrailer2);
		validator.CollectionSize(x => x.LN1, 1, 5);
		validator.CollectionSize(x => x.LVID, 1, 999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
