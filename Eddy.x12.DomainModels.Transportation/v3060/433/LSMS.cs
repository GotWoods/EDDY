using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._433;

public class LSMS {
	[SectionPosition(1)] public SMS_StationCodesSegment StationCodesSegment { get; set; } = new();
	[SectionPosition(2)] public SMR_CrossReference CrossReference { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(5)] public List<LSMS_LCD> LCD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSMS>(this);
		validator.Required(x => x.StationCodesSegment);
		validator.Required(x => x.CrossReference);
		validator.CollectionSize(x => x.LCD, 0, 150);
		foreach (var item in LCD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
