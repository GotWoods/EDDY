using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMR*G*piRYIo*ZRtTan*8b*ZP";

		var expected = new SMR_CrossReference()
		{
			LocationQualifier = "G",
			StandardPointLocationCode = "piRYIo",
			Date = "ZRtTan",
			CityName = "8b",
			StateOrProvinceCode = "ZP",
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
		subject.StandardPointLocationCode = "piRYIo";
		subject.Date = "ZRtTan";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("piRYIo", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "G";
		subject.Date = "ZRtTan";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZRtTan", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMR_CrossReference();
		//Required fields
		subject.LocationQualifier = "G";
		subject.StandardPointLocationCode = "piRYIo";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
