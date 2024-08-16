using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class E008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:i:i:v:s:0vRR:p:U:F:4:v:3:6";

		var expected = new E008_GeographicDetails()
		{
			PlaceLocationQualifier = "n",
			PlaceLocation = "i",
			RelationCoded = "i",
			Quantity = "v",
			QuantityQualifier = "s",
			Time = "0vRR",
			TypeOfMeansOfTransportIdentification = "p",
			TypeOfMeansOfTransportIdentification2 = "U",
			TypeOfMeansOfTransportIdentification3 = "F",
			TypeOfMeansOfTransportIdentification4 = "4",
			TypeOfMeansOfTransportIdentification5 = "v",
			Latitude = "3",
			Longitude = "6",
		};

		var actual = Map.MapComposite<E008_GeographicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredPlaceLocationQualifier(string placeLocationQualifier, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.PlaceLocation = "i";
		//Test Parameters
		subject.PlaceLocationQualifier = placeLocationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredPlaceLocation(string placeLocation, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.PlaceLocationQualifier = "n";
		//Test Parameters
		subject.PlaceLocation = placeLocation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
