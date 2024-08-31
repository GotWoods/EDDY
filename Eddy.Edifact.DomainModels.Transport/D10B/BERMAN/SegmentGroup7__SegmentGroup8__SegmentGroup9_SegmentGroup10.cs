using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.BERMAN;

public class SegmentGroup7__SegmentGroup8__SegmentGroup9_SegmentGroup10 {
	[SectionPosition(1)] public GDS_NatureOfCargo NatureOfCargo { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	[SectionPosition(5)] public List<DGS_DangerousGoods> DangerousGoods { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7__SegmentGroup8__SegmentGroup9_SegmentGroup10>(this);
		validator.Required(x => x.NatureOfCargo);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		validator.CollectionSize(x => x.DangerousGoods, 1, 9);
		return validator.Results;
	}
}
