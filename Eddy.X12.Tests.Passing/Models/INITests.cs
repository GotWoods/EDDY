using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INI*9R*XUfaYU3b*6";

		var expected = new INI_IncorporationInformation()
		{
			StateOrProvinceCode = "9R",
			Date = "XUfaYU3b",
			EntityTypeQualifier = "6",
		};

		var actual = Map.MapObject<INI_IncorporationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9R", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new INI_IncorporationInformation();
		subject.Date = "XUfaYU3b";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XUfaYU3b", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new INI_IncorporationInformation();
		subject.StateOrProvinceCode = "9R";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
