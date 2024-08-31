using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12B;

namespace Eddy.Edifact.DomainModels.Transport.D12B.IFCSUM;

public class SegmentGroup27__SegmentGroup53_SegmentGroup58 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public DIM_Dimensions Dimensions { get; set; } = new();
	[SectionPosition(7)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup53_SegmentGroup58>(this);
		validator.Required(x => x.PackageIdentification);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9999);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.Required(x => x.Dimensions);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
