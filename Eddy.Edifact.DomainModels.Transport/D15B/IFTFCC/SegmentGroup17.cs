using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.IFTFCC;

public class SegmentGroup17 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(5)] public List<SegmentGroup17_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 99);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
