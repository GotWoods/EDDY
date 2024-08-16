using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:d:Y:V:x:GG7S:o:z:0:H:P:z:L";

		var expected = new E008_GeographicDetails()
		{
			LocationFunctionCodeQualifier = "x",
			LocationName = "d",
			RelationCoded = "Y",
			Quantity = "V",
			QuantityTypeCodeQualifier = "x",
			Time = "GG7S",
			TransportMeansDescriptionCode = "o",
			TransportMeansDescriptionCode2 = "z",
			TransportMeansDescriptionCode3 = "0",
			TransportMeansDescriptionCode4 = "H",
			TransportMeansDescriptionCode5 = "P",
			Latitude = "z",
			Longitude = "L",
		};

		var actual = Map.MapComposite<E008_GeographicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationName = "d";
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationName(string locationName, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationFunctionCodeQualifier = "x";
		//Test Parameters
		subject.LocationName = locationName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
