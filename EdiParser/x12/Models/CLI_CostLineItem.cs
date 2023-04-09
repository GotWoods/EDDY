using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CLI")]
public class CLI_CostLineItem : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(03)]
	public string AssignedIdentification { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	[Position(05)]
	public string RateOrValueTypeCode { get; set; }

	[Position(06)]
	public string ContractTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLI_CostLineItem>(this);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.RateOrValueTypeCode, 1, 2);
		validator.Length(x => x.ContractTypeCode, 2);
		return validator.Results;
	}
}
