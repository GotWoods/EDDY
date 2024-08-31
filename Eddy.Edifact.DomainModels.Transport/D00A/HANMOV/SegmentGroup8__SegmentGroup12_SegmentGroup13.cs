using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.HANMOV;

public class SegmentGroup8__SegmentGroup12_SegmentGroup13 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup8__SegmentGroup12_SegmentGroup13>(this);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9);
		return validator.Results;
	}
}
