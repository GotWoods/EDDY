using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*S*vzOxM4*kw9b*o*3*Qs*B*f*Tm*1*4*3*1*6*4*Z";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "S",
			Date = "vzOxM4",
			Time = "kw9b",
			LocationQualifier = "o",
			LocationIdentifier = "3",
			StateOrProvinceCode = "Qs",
			LocationQualifier2 = "B",
			LocationIdentifier2 = "f",
			StateOrProvinceCode2 = "Tm",
			MeasurementValue = 1,
			MeasurementValue2 = 4,
			MonetaryAmount = 3,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 6,
			MonetaryAmount4 = 4,
			RelationshipCode = "Z",
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "3", true)]
	[InlineData("o", "", false)]
	[InlineData("", "3", false)]
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
			subject.LocationQualifier2 = "B";
			subject.LocationIdentifier2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "f", true)]
	[InlineData("B", "", false)]
	[InlineData("", "f", false)]
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
			subject.LocationQualifier = "o";
			subject.LocationIdentifier = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
