using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._204;

public class L0300_L0320 {
	[SectionPosition(1)] public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(2)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(3)] public AT5_BillOfLadingHandlingRequirements? BillOfLadingHandlingRequirements { get; set; }
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(7)] public List<L0300__L0320_L0325> L0325 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0320>(this);
		validator.Required(x => x.DescriptionMarksAndNumbers);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.L0325, 0, 99);
		foreach (var item in L0325) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
