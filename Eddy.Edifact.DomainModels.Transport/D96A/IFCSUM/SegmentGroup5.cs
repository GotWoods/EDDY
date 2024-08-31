using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup5 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(5)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(6)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(7)] public List<SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup5_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup5_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup5_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
