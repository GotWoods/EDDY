using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17B;

namespace Eddy.Edifact.DomainModels.Transport.D17B.IFTFCC;

public class SegmentGroup6_SegmentGroup8 {
	[SectionPosition(1)] public MOA_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup6__SegmentGroup8_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(3)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup6__SegmentGroup8_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup8>(this);
		validator.Required(x => x.MonetaryAmount);
		validator.Required(x => x.PercentageDetails);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
