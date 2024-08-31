using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.HANMOV;

public class SegmentGroup7 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7>(this);
		validator.Required(x => x.TransportInformation);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
