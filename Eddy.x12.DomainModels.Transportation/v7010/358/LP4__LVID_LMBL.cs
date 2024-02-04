using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._358;

public class LP4__LVID_LMBL {
	[SectionPosition(1)] public MBL_BillOfLading BillOfLading { get; set; } = new();
	[SectionPosition(2)] public M13_ManifestAmendmentDetails? ManifestAmendmentDetails { get; set; }
	[SectionPosition(3)] public X1_ExportLicense? ExportLicense { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LVID_LMBL>(this);
		validator.Required(x => x.BillOfLading);
		return validator.Results;
	}
}
