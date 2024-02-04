using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._601;

public class LBA1_LL13 {
	[SectionPosition(1)] public L13_CommodityDetails CommodityDetails { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(4)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(5)] public List<LBA1__LL13_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBA1_LL13>(this);
		validator.Required(x => x.CommodityDetails);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
