using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E008")]
public class E008_GeographicDetails : EdifactComponent
{
	[Position(1)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string LocationName { get; set; }

	[Position(3)]
	public string RelationCode { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string QuantityTypeCodeQualifier { get; set; }

	[Position(6)]
	public string TimeValue { get; set; }

	[Position(7)]
	public string TransportMeansDescriptionCode { get; set; }

	[Position(8)]
	public string TransportMeansDescriptionCode2 { get; set; }

	[Position(9)]
	public string TransportMeansDescriptionCode3 { get; set; }

	[Position(10)]
	public string TransportMeansDescriptionCode4 { get; set; }

	[Position(11)]
	public string TransportMeansDescriptionCode5 { get; set; }

	[Position(12)]
	public string LatitudeValue { get; set; }

	[Position(13)]
	public string LongitudeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E008_GeographicDetails>(this);
		validator.Required(x=>x.LocationFunctionCodeQualifier);
		validator.Required(x=>x.LocationName);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.RelationCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		validator.Length(x => x.TimeValue, 4);
		validator.Length(x => x.TransportMeansDescriptionCode, 1, 8);
		validator.Length(x => x.TransportMeansDescriptionCode2, 1, 8);
		validator.Length(x => x.TransportMeansDescriptionCode3, 1, 8);
		validator.Length(x => x.TransportMeansDescriptionCode4, 1, 8);
		validator.Length(x => x.TransportMeansDescriptionCode5, 1, 8);
		validator.Length(x => x.LatitudeValue, 1, 10);
		validator.Length(x => x.LongitudeValue, 1, 11);
		return validator.Results;
	}
}
