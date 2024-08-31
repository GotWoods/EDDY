using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.IFTFCC;

public class SegmentGroup11 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<FII_FinancialInstitutionInformation> FinancialInstitutionInformation { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup11_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.FinancialInstitutionInformation, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
