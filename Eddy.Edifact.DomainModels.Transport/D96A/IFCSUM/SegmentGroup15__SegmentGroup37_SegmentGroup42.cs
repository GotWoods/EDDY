using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15__SegmentGroup37_SegmentGroup42 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15__SegmentGroup37_SegmentGroup42>(this);
		validator.Required(x => x.PackageIdentification);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9);
		return validator.Results;
	}
}
