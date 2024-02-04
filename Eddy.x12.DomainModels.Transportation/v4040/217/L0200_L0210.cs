using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._217;

public class L0200_L0210 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(3)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(4)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(5)] public SV_ServiceDescription ServiceDescription { get; set; } = new();
	[SectionPosition(6)] public List<RST_CarrierRestriction> CarrierRestriction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Name, 0, 3);
		validator.CollectionSize(x => x.Geography, 0, 9999);
		validator.CollectionSize(x => x.GeographicLocation, 0, 9999);
		validator.Required(x => x.ServiceDescription);
		validator.CollectionSize(x => x.CarrierRestriction, 0, 10);
		return validator.Results;
	}
}
