using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.DomainModels.Transport.D96A.COSTCO;

namespace Eddy.Edifact.DomainModels.Transport.D96A;

public class COSTCO_ContainerStuffingStrippingConfirmation {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(5)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(9)] public CNT_ControlTotal ControlTotal { get; set; } = new();
	[SectionPosition(10)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<COSTCO_ContainerStuffingStrippingConfirmation>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.Required(x => x.ControlTotal);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
