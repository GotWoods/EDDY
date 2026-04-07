using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._262;

public class L2000 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<AM1_InformationalValues> InformationalValues { get; set; } = new();
	[SectionPosition(3)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(4)] public List<SPI_SpecificationIdentifier> SpecificationIdentifier { get; set; } = new();
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<L2000_L2100> L2100 {get;set;} = new();
	[SectionPosition(7)] public List<L2000_L2200> L2200 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.InformationalValues, 1, 2147483647);
		validator.CollectionSize(x => x.Paperwork, 0, 5);
		validator.CollectionSize(x => x.SpecificationIdentifier, 1, 2147483647);
		validator.CollectionSize(x => x.L2100, 1, 2147483647);
		validator.CollectionSize(x => x.L2200, 1, 2147483647);
		foreach (var item in L2100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
