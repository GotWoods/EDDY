using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("R2A")]
public class R2A_RouteInformationWithPreference : EdiX12Segment
{
	[Position(01)]
	public string RoutingSequenceCode { get; set; }

	[Position(02)]
	public string Preference { get; set; }

	[Position(03)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string LocationQualifier { get; set; }

	[Position(06)]
	public string LocationIdentifier { get; set; }

	[Position(07)]
	public string TypeOfServiceCode { get; set; }

	[Position(08)]
	public string RouteCode { get; set; }

	[Position(09)]
	public string RouteDescription { get; set; }

	[Position(10)]
	public string EntityIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R2A_RouteInformationWithPreference>(this);
		validator.Required(x=>x.RoutingSequenceCode);
		validator.Required(x=>x.Preference);
		validator.ARequiresB(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.Preference, 1);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.RouteDescription, 1, 35);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		return validator.Results;
	}
}
