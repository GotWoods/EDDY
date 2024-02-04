using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._350;

public class LBA1 {
	[SectionPosition(1)] public BA1_ExportShipmentIdentifyingInformation ExportShipmentIdentifyingInformation { get; set; } = new();
	[SectionPosition(2)] public List<LBA1_LX4> LX4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBA1>(this);
		validator.Required(x => x.ExportShipmentIdentifyingInformation);
		validator.CollectionSize(x => x.LX4, 0, 9999);
		foreach (var item in LX4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
