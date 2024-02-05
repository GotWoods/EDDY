using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v8040._868;

public class LE30 {
	[SectionPosition(1)] public E30_DataElementAttributes DataElementAttributes { get; set; } = new();
	[SectionPosition(2)] public List<DAI_AppendixInformation> AppendixInformation { get; set; } = new();
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<LE30_LE34> LE34 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE30>(this);
		validator.Required(x => x.DataElementAttributes);
		validator.CollectionSize(x => x.AppendixInformation, 0, 10);
		validator.CollectionSize(x => x.LE34, 0, 100000);
		foreach (var item in LE34) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
