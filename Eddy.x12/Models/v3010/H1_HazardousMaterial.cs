using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("H1")]
public class H1_HazardousMaterial : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialCode { get; set; }

	[Position(02)]
	public string HazardousMaterialClassCode { get; set; }

	[Position(03)]
	public string HazardousMaterialCodeQualifier { get; set; }

	[Position(04)]
	public string HazardousMaterialDescription { get; set; }

	[Position(05)]
	public string HazardousMaterialContact { get; set; }

	[Position(06)]
	public string HazardousMaterialsPage { get; set; }

	[Position(07)]
	public string FlashpointTemperature { get; set; }

	[Position(08)]
	public string UnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<H1_HazardousMaterial>(this);
		validator.Required(x=>x.HazardousMaterialCode);
		validator.Length(x => x.HazardousMaterialCode, 4, 10);
		validator.Length(x => x.HazardousMaterialClassCode, 2, 4);
		validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
		validator.Length(x => x.HazardousMaterialDescription, 2, 30);
		validator.Length(x => x.HazardousMaterialContact, 1, 24);
		validator.Length(x => x.HazardousMaterialsPage, 1, 6);
		validator.Length(x => x.FlashpointTemperature, 1, 3);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		return validator.Results;
	}
}
