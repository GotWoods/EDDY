using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._194;

public class LHL__LN9_LINX {
	[SectionPosition(1)] public INX_IndexDetail IndexDetail { get; set; } = new();
	[SectionPosition(2)] public List<K3_FileInformation> FileInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LN9_LINX>(this);
		validator.Required(x => x.IndexDetail);
		validator.CollectionSize(x => x.FileInformation, 1, 2147483647);
		return validator.Results;
	}
}
