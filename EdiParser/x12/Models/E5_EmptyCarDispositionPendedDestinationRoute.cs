using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("E5")]
public class E5_EmptyCarDispositionPendedDestinationRoute : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string RoutingSequenceCode { get; set; }

	[Position(03)]
	public string CityName { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E5_EmptyCarDispositionPendedDestinationRoute>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.RoutingSequenceCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		return validator.Results;
	}
}
