using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.HANMOV;

public class SegmentGroup12__SegmentGroup13__SegmentGroup18_SegmentGroup19 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12__SegmentGroup13__SegmentGroup18_SegmentGroup19>(this);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9);
		return validator.Results;
	}
}
