using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("TMD")]
public class TMD_TestMethod : EdiX12Segment
{
	[Position(01)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string ProductDescriptionCode { get; set; }

	[Position(04)]
	public string TestAdministrationMethodCode { get; set; }

	[Position(05)]
	public string TestMediumCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string SourceSubqualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TMD_TestMethod>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.ProductDescriptionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.TestAdministrationMethodCode, 2);
		validator.Length(x => x.TestMediumCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		return validator.Results;
	}
}
