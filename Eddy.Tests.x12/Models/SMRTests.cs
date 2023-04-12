using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMR*V*qEZnsf*Ke*13";

		var expected = new SMR_CrossReference()
		{
			LocationQualifier = "V",
			StandardPointLocationCode = "qEZnsf",
			CityName = "Ke",
			StateOrProvinceCode = "13",
		};

		var actual = Map.MapObject<SMR_CrossReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("qEZnsf","Ke", true)]
	[InlineData("", "Ke", true)]
	[InlineData("qEZnsf", "", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		subject.LocationQualifier = "V";
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ke", "13", true)]
	[InlineData("", "13", false)]
	[InlineData("Ke", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		subject.LocationQualifier = "V";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
