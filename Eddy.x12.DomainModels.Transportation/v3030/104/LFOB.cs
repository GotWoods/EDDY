using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._104;

public class LFOB {
	[SectionPosition(1)] public FOB_FOBRelatedInstructions FOBRelatedInstructions { get; set; } = new();
	[SectionPosition(2)] public SL1_TariffReference TariffReference { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth> CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth { get; set; } = new();
	[SectionPosition(5)] public H1_HazardousMaterial? HazardousMaterial { get; set; }
	[SectionPosition(6)] public H2_AdditionalHazardousMaterialDescription? AdditionalHazardousMaterialDescription { get; set; }
	[SectionPosition(7)] public H3_SpecialHandlingInstructions? SpecialHandlingInstructions { get; set; }
	[SectionPosition(8)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(9)] public M1_Insurance? Insurance { get; set; }
	[SectionPosition(10)] public C3_Currency? Currency { get; set; }
	[SectionPosition(11)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(12)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(13)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(14)] public List<LFOB_LN1> LN1 {get;set;} = new();
	[SectionPosition(15)] public List<LFOB_LL5> LL5 {get;set;} = new();
	[SectionPosition(16)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFOB>(this);
		validator.Required(x => x.FOBRelatedInstructions);
		validator.Required(x => x.TariffReference);
		validator.CollectionSize(x => x.ReferenceNumber, 1, 10);
		validator.CollectionSize(x => x.CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 100);
		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LL5, 1, 100);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
