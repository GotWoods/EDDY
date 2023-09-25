using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMR*5*e0d1Eu*Mhz1c5*5S*WJ";

		var expected = new SMR_CrossReference()
		{
			LocationQualifier = "5",
			StandardPointLocationCode = "e0d1Eu",
			Date = "Mhz1c5",
			CityName = "5S",
			StateOrProvinceCode = "WJ",
		};

		var actual = Map.MapObject<SMR_CrossReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.Date = "Mhz1c5";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.StandardPointLocationCode = "e0d1Eu";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5S";
			subject.StateOrProvinceCode = "WJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("e0d1Eu", "5S", true)]
	[InlineData("e0d1Eu", "", true)]
	[InlineData("", "5S", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "5";
		subject.Date = "Mhz1c5";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5S";
			subject.StateOrProvinceCode = "WJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mhz1c5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "5";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.StandardPointLocationCode = "e0d1Eu";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5S";
			subject.StateOrProvinceCode = "WJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5S", "WJ", true)]
	[InlineData("5S", "", false)]
	[InlineData("", "WJ", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "5";
		subject.Date = "Mhz1c5";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.StandardPointLocationCode = "e0d1Eu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
