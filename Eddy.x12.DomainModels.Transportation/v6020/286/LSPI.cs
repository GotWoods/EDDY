using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._286;

public class LSPI {
	[SectionPosition(1)] public SPI_SpecificationIdentifier SpecificationIdentifier { get; set; } = new();
	[SectionPosition(2)] public List<LSPI_LHL> LHL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSPI>(this);
		validator.Required(x => x.SpecificationIdentifier);
		validator.CollectionSize(x => x.LHL, 1, 2147483647);
		foreach (var item in LHL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
