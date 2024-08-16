using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:c:O:L:a:Bwv9:h:U:h:X:Q";

		var expected = new E008_GeographicDetails()
		{
			PlaceLocationQualifier = "e",
			PlaceLocation = "c",
			RelationCoded = "O",
			Quantity = "L",
			QuantityQualifier = "a",
			Time = "Bwv9",
			TypeOfMeansOfTransportIdentification = "h",
			TypeOfMeansOfTransportIdentification2 = "U",
			TypeOfMeansOfTransportIdentification3 = "h",
			TypeOfMeansOfTransportIdentification4 = "X",
			TypeOfMeansOfTransportIdentification5 = "Q",
		};

		var actual = Map.MapComposite<E008_GeographicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPlaceLocationQualifier(string placeLocationQualifier, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.PlaceLocation = "c";
		//Test Parameters
		subject.PlaceLocationQualifier = placeLocationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredPlaceLocation(string placeLocation, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.PlaceLocationQualifier = "e";
		//Test Parameters
		subject.PlaceLocation = placeLocation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
