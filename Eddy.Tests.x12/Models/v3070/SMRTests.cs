using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMR*G*e7pSDI*aYbKo6*zY*bw";

		var expected = new SMR_CrossReference()
		{
			LocationQualifier = "G",
			StandardPointLocationCode = "e7pSDI",
			Date = "aYbKo6",
			CityName = "zY",
			StateOrProvinceCode = "bw",
		};

		var actual = Map.MapObject<SMR_CrossReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.StandardPointLocationCode = "e7pSDI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "zY";
			subject.StateOrProvinceCode = "bw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("e7pSDI", "zY", true)]
	[InlineData("e7pSDI", "", true)]
	[InlineData("", "zY", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "G";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "zY";
			subject.StateOrProvinceCode = "bw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zY", "bw", true)]
	[InlineData("zY", "", false)]
	[InlineData("", "bw", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "G";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.StandardPointLocationCode = "e7pSDI";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
