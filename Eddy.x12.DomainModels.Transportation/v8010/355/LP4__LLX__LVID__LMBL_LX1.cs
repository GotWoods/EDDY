using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._355;

public class LP4__LLX__LVID__LMBL_LX1 {
	[SectionPosition(1)] public X1_ExportLicense ExportLicense { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID__LMBL_LX1>(this);
		validator.Required(x => x.ExportLicense);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
