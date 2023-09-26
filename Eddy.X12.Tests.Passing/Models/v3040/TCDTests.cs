using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*7*pyFjvh*hxjn*C*1*1O*4*a*lc*2*3*9*2*5*8*0";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "7",
			Date = "pyFjvh",
			Time = "hxjn",
			LocationQualifier = "C",
			LocationIdentifier = "1",
			StateOrProvinceCode = "1O",
			LocationQualifier2 = "4",
			LocationIdentifier2 = "a",
			StateOrProvinceCode2 = "lc",
			MeasurementValue = 2,
			MeasurementValue2 = 3,
			MonetaryAmount = 9,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 5,
			MonetaryAmount4 = 8,
			PriceRelationshipCode = "0",
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "1", true)]
	[InlineData("C", "", false)]
	[InlineData("", "1", false)]
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
			subject.LocationQualifier2 = "4";
			subject.LocationIdentifier2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "a", true)]
	[InlineData("4", "", false)]
	[InlineData("", "a", false)]
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
			subject.LocationQualifier = "C";
			subject.LocationIdentifier = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
