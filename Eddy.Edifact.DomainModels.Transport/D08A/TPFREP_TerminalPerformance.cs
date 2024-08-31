using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;
using Eddy.Edifact.DomainModels.Transport.D08A.TPFREP;

namespace Eddy.Edifact.DomainModels.Transport.D08A;

public class TPFREP_TerminalPerformance {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(6)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<TPFREP_TerminalPerformance>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.DateTimePeriod);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup2, 0, 99);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
