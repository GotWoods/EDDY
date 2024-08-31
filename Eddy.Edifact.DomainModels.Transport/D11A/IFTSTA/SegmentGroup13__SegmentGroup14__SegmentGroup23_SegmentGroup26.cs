using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11A;

namespace Eddy.Edifact.DomainModels.Transport.D11A.IFTSTA;

public class SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup26 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup26>(this);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9999);
		return validator.Results;
	}
}
