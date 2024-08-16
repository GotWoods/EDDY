using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("E008")]
public class E008_GeographicDetails : EdifactComponent
{
	[Position(1)]
	public string PlaceLocationQualifier { get; set; }

	[Position(2)]
	public string PlaceLocation { get; set; }

	[Position(3)]
	public string RelationCoded { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string QuantityQualifier { get; set; }

	[Position(6)]
	public string Time { get; set; }

	[Position(7)]
	public string TypeOfMeansOfTransportIdentification { get; set; }

	[Position(8)]
	public string TypeOfMeansOfTransportIdentification2 { get; set; }

	[Position(9)]
	public string TypeOfMeansOfTransportIdentification3 { get; set; }

	[Position(10)]
	public string TypeOfMeansOfTransportIdentification4 { get; set; }

	[Position(11)]
	public string TypeOfMeansOfTransportIdentification5 { get; set; }

	[Position(12)]
	public string Latitude { get; set; }

	[Position(13)]
	public string Longitude { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E008_GeographicDetails>(this);
		validator.Required(x=>x.PlaceLocationQualifier);
		validator.Required(x=>x.PlaceLocation);
		validator.Length(x => x.PlaceLocationQualifier, 1, 3);
		validator.Length(x => x.PlaceLocation, 1, 70);
		validator.Length(x => x.RelationCoded, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.QuantityQualifier, 1, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification, 1, 8);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification2, 1, 8);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification3, 1, 8);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification4, 1, 8);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification5, 1, 8);
		validator.Length(x => x.Latitude, 1, 10);
		validator.Length(x => x.Longitude, 1, 11);
		return validator.Results;
	}
}
