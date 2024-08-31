using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13A;

namespace Eddy.Edifact.DomainModels.Transport.D13A.IFTFCC;

public class SegmentGroup6 {
	[SectionPosition(1)] public TCC_ChargeRateCalculations ChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(7)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup6_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.ChargeRateCalculations);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
