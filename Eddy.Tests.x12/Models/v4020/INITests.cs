using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class INITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INI*uq*QRE7tqmi*6";

		var expected = new INI_IncorporationInformation()
		{
			StateOrProvinceCode = "uq",
			Date = "QRE7tqmi",
			EntityTypeQualifier = "6",
		};

		var actual = Map.MapObject<INI_IncorporationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uq", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new INI_IncorporationInformation();
		//Required fields
		subject.Date = "QRE7tqmi";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QRE7tqmi", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new INI_IncorporationInformation();
		//Required fields
		subject.StateOrProvinceCode = "uq";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
