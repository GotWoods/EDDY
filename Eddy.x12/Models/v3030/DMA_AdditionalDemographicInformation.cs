using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("DMA")]
public class DMA_AdditionalDemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	[Position(04)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(05)]
	public string ApplicantTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMA_AdditionalDemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumber2, x=>x.StateOrProvinceCode2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.ApplicantTypeCode, 1);
		return validator.Results;
	}
}
