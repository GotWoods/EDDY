using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._350;

public class LP4 {
	[SectionPosition(1)] public P4_USPortInformation USPortInformation { get; set; } = new();
	[SectionPosition(2)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(3)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(4)] public List<LP4_LN9> LN9 {get;set;} = new();
	[SectionPosition(5)] public List<LP4_LX4> LX4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.USPortInformation);
		validator.CollectionSize(x => x.EventDetail, 0, 20);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		validator.CollectionSize(x => x.LN9, 0, 999);
		validator.CollectionSize(x => x.LX4, 0, 9999);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LX4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
