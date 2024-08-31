using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.IFCSUM;

public class SegmentGroup25__SegmentGroup50_SegmentGroup55 {
	[SectionPosition(1)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(2)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(3)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public DIM_Dimensions Dimensions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50_SegmentGroup55>(this);
		validator.Required(x => x.PackageIdentification);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.Required(x => x.Dimensions);
		return validator.Results;
	}
}
