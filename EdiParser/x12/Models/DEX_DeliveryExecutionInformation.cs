using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DEX")]
public class DEX_DeliveryExecutionInformation : EdiX12Segment
{
	[Position(01)]
	public string SalesTermsCode { get; set; }

	[Position(02)]
	public string RemittanceTypeCode { get; set; }

	[Position(03)]
	public string InvestorOwnershipTypeCode { get; set; }

	[Position(04)]
	public int? Number { get; set; }

	[Position(05)]
	public string CodeListQualifierCode { get; set; }

	[Position(06)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEX_DeliveryExecutionInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.SalesTermsCode, 2);
		validator.Length(x => x.RemittanceTypeCode, 2);
		validator.Length(x => x.InvestorOwnershipTypeCode, 1, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
