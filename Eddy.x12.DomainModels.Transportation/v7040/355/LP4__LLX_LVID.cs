using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._355;

public class LP4__LLX_LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LVID_LM7> LM7 {get;set;} = new();
	[SectionPosition(4)] public List<LP4__LLX__LVID_LMBL> LMBL {get;set;} = new();
	[SectionPosition(5)] public List<LP4__LLX__LVID_LVC> LVC {get;set;} = new();
	[SectionPosition(6)] public List<LP4__LLX__LVID_LN10> LN10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LMBL, 0, 9999);
		validator.CollectionSize(x => x.LVC, 0, 36);
		validator.CollectionSize(x => x.LN10, 0, 999);
		foreach (var item in LM7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
