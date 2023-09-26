using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G30")]
public class G30_StoreElectronicMarketingTypes : EdiX12Segment
{
	[Position(01)]
	public string ElectronicMarketingTypeCode { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G30_StoreElectronicMarketingTypes>(this);
		validator.Required(x=>x.ElectronicMarketingTypeCode);
		validator.Length(x => x.ElectronicMarketingTypeCode, 1, 2);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
