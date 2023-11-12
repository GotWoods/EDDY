using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G49")]
public class G49_StatementTotal : EdiX12Segment
{
	[Position(01)]
	public string TotalStatementAmount { get; set; }

	[Position(02)]
	public string PriorBalance { get; set; }

	[Position(03)]
	public string CurrentBalance { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G49_StatementTotal>(this);
		validator.Required(x=>x.TotalStatementAmount);
		validator.Length(x => x.TotalStatementAmount, 1, 10);
		validator.Length(x => x.PriorBalance, 2, 10);
		validator.Length(x => x.CurrentBalance, 2, 10);
		return validator.Results;
	}
}
