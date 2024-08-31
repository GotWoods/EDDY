using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.BMISRM;

public class SegmentGroup1 {
	[SectionPosition(1)] public PNA_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public ADR_Address Address { get; set; } = new();
	[SectionPosition(3)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup1_SegmentGroup2> SegmentGroup2 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.Required(x => x.Address);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
