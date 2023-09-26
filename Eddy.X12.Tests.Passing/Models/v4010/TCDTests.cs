using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*U*wywicRZz*EHW9*H*u*4D*f*I*4Z*6*9*2*2*9*2*9";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "U",
			Date = "wywicRZz",
			Time = "EHW9",
			LocationQualifier = "H",
			LocationIdentifier = "u",
			StateOrProvinceCode = "4D",
			LocationQualifier2 = "f",
			LocationIdentifier2 = "I",
			StateOrProvinceCode2 = "4Z",
			MeasurementValue = 6,
			MeasurementValue2 = 9,
			MonetaryAmount = 2,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 9,
			MonetaryAmount4 = 2,
			RelationshipCode = "9",
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "u", true)]
	[InlineData("H", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "f";
			subject.LocationIdentifier2 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "I", true)]
	[InlineData("f", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		//Required fields
		//Test Parameters
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "H";
			subject.LocationIdentifier = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
