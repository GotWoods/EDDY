using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("SFC")]
public class SFC_StorageFacilityCharacteristics : EdiX12Segment
{
	[Position(01)]
	public string FacilityCharacteristicCodeQualifier { get; set; }

	[Position(02)]
	public string FacilityCharacteristicCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SFC_StorageFacilityCharacteristics>(this);
		validator.Required(x=>x.FacilityCharacteristicCodeQualifier);
		validator.Required(x=>x.FacilityCharacteristicCode);
		validator.Length(x => x.FacilityCharacteristicCodeQualifier, 1);
		validator.Length(x => x.FacilityCharacteristicCode, 1, 2);
		return validator.Results;
	}
}
