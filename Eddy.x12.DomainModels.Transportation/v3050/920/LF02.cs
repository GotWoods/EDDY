using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._920;

public class LF02 {
	[SectionPosition(1)] public F02_IdentificationOfShipment IdentificationOfShipment { get; set; } = new();
	[SectionPosition(2)] public F05_AllowanceChargeClaim? AllowanceChargeClaim { get; set; }
	[SectionPosition(3)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(4)] public List<LF02_LF09> LF09 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF02>(this);
		validator.Required(x => x.IdentificationOfShipment);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.LF09, 0, 100);
		foreach (var item in LF09) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
