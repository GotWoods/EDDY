using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMR*R*Ei89lU*YA*A1";

		var expected = new SMR_CrossReference()
		{
			LocationQualifier = "R",
			StandardPointLocationCode = "Ei89lU",
			CityName = "YA",
			StateOrProvinceCode = "A1",
		};

		var actual = Map.MapObject<SMR_CrossReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.StandardPointLocationCode = "Ei89lU";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "YA";
			subject.StateOrProvinceCode = "A1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Ei89lU", "YA", true)]
	[InlineData("Ei89lU", "", true)]
	[InlineData("", "YA", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "R";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "YA";
			subject.StateOrProvinceCode = "A1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YA", "A1", true)]
	[InlineData("YA", "", false)]
	[InlineData("", "A1", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "R";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.StandardPointLocationCode = "Ei89lU";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
