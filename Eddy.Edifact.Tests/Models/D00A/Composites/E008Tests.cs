using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:o:S:J:P:XO2i:8:p:D:l:S:F:U";

		var expected = new E008_GeographicDetails()
		{
			LocationFunctionCodeQualifier = "s",
			LocationName = "o",
			RelationCode = "S",
			Quantity = "J",
			QuantityTypeCodeQualifier = "P",
			TimeValue = "XO2i",
			TransportMeansDescriptionCode = "8",
			TransportMeansDescriptionCode2 = "p",
			TransportMeansDescriptionCode3 = "D",
			TransportMeansDescriptionCode4 = "l",
			TransportMeansDescriptionCode5 = "S",
			LatitudeValue = "F",
			LongitudeValue = "U",
		};

		var actual = Map.MapComposite<E008_GeographicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredLocationFunctionCodeQualifier(string locationFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationName = "o";
		//Test Parameters
		subject.LocationFunctionCodeQualifier = locationFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredLocationName(string locationName, bool isValidExpected)
	{
		var subject = new E008_GeographicDetails();
		//Required fields
		subject.LocationFunctionCodeQualifier = "s";
		//Test Parameters
		subject.LocationName = locationName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
