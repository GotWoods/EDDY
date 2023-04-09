using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CER")]
public class CER_Certification : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string NameLastOrOrganizationName { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(06)]
	public string IdentificationCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CER_Certification>(this);
		validator.AtLeastOneIsRequired(x=>x.AgencyQualifierCode, x=>x.NameLastOrOrganizationName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.NameLastOrOrganizationName, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
