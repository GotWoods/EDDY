using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._284;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public PWK_Paperwork? Paperwork { get; set; }
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public TC2_Commodity? Commodity { get; set; }
	[SectionPosition(7)] public H1_HazardousMaterial? HazardousMaterial { get; set; }
	[SectionPosition(8)] public LH2_HazardousClassificationInformation? HazardousClassificationInformation { get; set; }
	[SectionPosition(9)] public LH3_HazardousMaterialShippingNameInformation? HazardousMaterialShippingNameInformation { get; set; }
	[SectionPosition(10)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(11)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(12)] public List<LHL_LLQ> LLQ {get;set;} = new();
	[SectionPosition(13)] public List<LHL_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(14)] public List<LHL_LMTX> LMTX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LMTX, 1, 2147483647);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LMTX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
