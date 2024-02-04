using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._601;

public class LBA1_LL13 {
	[SectionPosition(1)] public L13_CommodityDetails CommodityDetails { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(3)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(4)] public List<VEH_VehicleInformation> VehicleInformation { get; set; } = new();
	[SectionPosition(5)] public List<LBA1__LL13_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBA1_LL13>(this);
		validator.Required(x => x.CommodityDetails);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 999);
		validator.CollectionSize(x => x.VehicleInformation, 0, 9999);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
