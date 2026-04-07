using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._266;

public class L0200__L0220_L0222 {
	[SectionPosition(1)] public API_ActivityOrProcessInformation ActivityOrProcessInformation { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(7)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(8)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(9)] public INT_Interest? Interest { get; set; }
	[SectionPosition(10)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(13)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0220_L0222>(this);
		validator.Required(x => x.ActivityOrProcessInformation);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.ProductItemDescription, 1, 2147483647);
		return validator.Results;
	}
}
