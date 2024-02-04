using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._355;

public class LP4__LLX__LVID_LMBL {
	[SectionPosition(1)] public MBL_BillOfLading BillOfLading { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LVID__LMBL_LM13> LM13 {get;set;} = new();
	[SectionPosition(4)] public List<LP4__LLX__LVID__LMBL_LX1> LX1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID_LMBL>(this);
		validator.Required(x => x.BillOfLading);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LM13, 0, 999);
		foreach (var item in LM13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LX1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
