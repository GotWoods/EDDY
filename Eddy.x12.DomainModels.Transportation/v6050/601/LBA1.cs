using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._601;

public class LBA1 {
	[SectionPosition(1)] public BA1_ExportShipmentIdentifyingInformation ExportShipmentIdentifyingInformation { get; set; } = new();
	[SectionPosition(2)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public V5_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public List<P5_PortFunction> PortFunction { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(8)] public List<VID_ConveyanceIdentification> ConveyanceIdentification { get; set; } = new();
	[SectionPosition(9)] public List<LBA1_LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public List<LBA1_LL13> LL13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBA1>(this);
		validator.Required(x => x.ExportShipmentIdentifyingInformation);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.PortFunction, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 9);
		validator.CollectionSize(x => x.ConveyanceIdentification, 0, 999);
		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LL13, 0, 999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
