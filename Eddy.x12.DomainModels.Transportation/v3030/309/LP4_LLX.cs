using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._309;

public class LP4_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public M13_ManifestAmendmentDetails? ManifestAmendmentDetails { get; set; }
	[SectionPosition(3)] public M11_ManifestBillOfLadingDetails ManifestBillOfLadingDetails { get; set; } = new();
	[SectionPosition(4)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<LP4__LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(8)] public List<LP4__LLX_LVID> LVID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.Required(x => x.ManifestBillOfLadingDetails);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.LN1, 1, 5);
		validator.CollectionSize(x => x.LVID, 1, 999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
