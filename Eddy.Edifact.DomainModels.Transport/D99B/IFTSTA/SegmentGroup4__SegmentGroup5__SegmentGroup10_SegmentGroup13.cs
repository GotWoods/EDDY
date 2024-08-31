using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.IFTSTA;

public class SegmentGroup4__SegmentGroup5__SegmentGroup10_SegmentGroup13 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5__SegmentGroup10_SegmentGroup13>(this);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9);
		return validator.Results;
	}
}
