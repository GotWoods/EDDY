using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("Y6")]
public class Y6_Authentication : EdiX12Segment
{
	[Position(01)]
	public string AuthorityIdentifierCode { get; set; }

	[Position(02)]
	public string Authority { get; set; }

	[Position(03)]
	public string AuthorizationDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y6_Authentication>(this);
		validator.Required(x=>x.Authority);
		validator.Required(x=>x.AuthorizationDate);
		validator.Length(x => x.AuthorityIdentifierCode, 2);
		validator.Length(x => x.Authority, 1, 20);
		validator.Length(x => x.AuthorizationDate, 8);
		return validator.Results;
	}
}
