using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("M1")]
public class M1_Insurance : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public int? CarriageValue { get; set; }

	[Position(03)]
	public string DeclaredValue { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M1_Insurance>(this);
		validator.Required(x=>x.CountryCode);
		validator.Required(x=>x.CarriageValue);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.CarriageValue, 2, 8);
		validator.Length(x => x.DeclaredValue, 2, 10);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		return validator.Results;
	}
}
