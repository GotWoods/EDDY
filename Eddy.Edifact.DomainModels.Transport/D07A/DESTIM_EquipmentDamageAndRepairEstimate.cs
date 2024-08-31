using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A;
using Eddy.Edifact.DomainModels.Transport.D07A.DESTIM;

namespace Eddy.Edifact.DomainModels.Transport.D07A;

public class DESTIM_EquipmentDamageAndRepairEstimate {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public GEI_ProcessingInformation ProcessingInformation { get; set; } = new();
	[SectionPosition(5)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(6)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(7)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<DESTIM_EquipmentDamageAndRepairEstimate>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.Required(x => x.ProcessingInformation);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		

		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
