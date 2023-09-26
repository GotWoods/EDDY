using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*d*ilcEq6*HGpQ*u*w*qQ*E*2*TC*6*4*2*3*2*9";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "d",
			Date = "ilcEq6",
			Time = "HGpQ",
			LocationQualifier = "u",
			LocationIdentifier = "w",
			StateOrProvinceCode = "qQ",
			LocationQualifier2 = "E",
			LocationIdentifier2 = "2",
			StateOrProvinceCode2 = "TC",
			MeasurementValue = 6,
			MeasurementValue2 = 4,
			MonetaryAmount = 2,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 9,
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "w", true)]
	[InlineData("u", "", false)]
	[InlineData("", "w", false)]
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
			subject.LocationQualifier2 = "E";
			subject.LocationIdentifier2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "2", true)]
	[InlineData("E", "", false)]
	[InlineData("", "2", false)]
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
			subject.LocationQualifier = "u";
			subject.LocationIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
