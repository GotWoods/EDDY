using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:n:n:2:6:K2La:L:a:t:F:G:m:2";

		var expected = new E008_GeographicDetails()
		{
			LocationFunctionCodeQualifier = "H",
			LocationName = "n",
			RelationCode = "n",
			Quantity = "2",
			QuantityTypeCodeQualifier = "6",
			Time = "K2La",
			TransportMeansDescriptionCode = "L",
			TransportMeansDescriptionCode2 = "a",
			TransportMeansDescriptionCode3 = "t",
			TransportMeansDescriptionCode4 = "F",
			TransportMeansDescriptionCode5 = "G",
			LatitudeDegree = "m",
			LongitudeDegree = "2",
		};

		var actual = Map.MapComposite<E008_GeographicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationName = "n";
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredLocationName(string locationName, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationFunctionCodeQualifier = "H";
		//Test Parameters
		subject.LocationName = locationName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
