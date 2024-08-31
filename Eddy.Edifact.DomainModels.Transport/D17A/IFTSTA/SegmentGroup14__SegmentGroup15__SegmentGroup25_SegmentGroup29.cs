using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.IFTSTA;

public class SegmentGroup14__SegmentGroup15__SegmentGroup25_SegmentGroup29 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14__SegmentGroup15__SegmentGroup25_SegmentGroup29>(this);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9999);
		return validator.Results;
	}
}
