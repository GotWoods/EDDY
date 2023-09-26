using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("DOS")]
public class DOS_DefinitionOfShare : EdiX12Segment
{
	[Position(01)]
	public string ContractTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? Percent2 { get; set; }

	[Position(06)]
	public string EntityIdentifierCode { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DOS_DefinitionOfShare>(this);
		validator.Required(x=>x.ContractTypeCode);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
