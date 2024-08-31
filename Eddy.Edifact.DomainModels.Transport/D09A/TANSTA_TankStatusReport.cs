using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;
using Eddy.Edifact.DomainModels.Transport.D09A.TANSTA;

namespace Eddy.Edifact.DomainModels.Transport.D09A;

public class TANSTA_TankStatusReport {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(5)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(8)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<TANSTA_TankStatusReport>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
