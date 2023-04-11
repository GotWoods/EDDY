using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CED*u*v*6*Z*7";

		var expected = new CED_AdministrationOfJusticeEventDescription()
		{
			AdministrationOfJusticeEventTypeCode = "u",
			ActionCode = "v",
			NoticeTypeCode = "6",
			CaseTypeCode = "Z",
			Description = "7",
		};

		var actual = Map.MapObject<CED_AdministrationOfJusticeEventDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validatation_RequiredAdministrationOfJusticeEventTypeCode(string administrationOfJusticeEventTypeCode, bool isValidExpected)
	{
		var subject = new CED_AdministrationOfJusticeEventDescription();
		subject.AdministrationOfJusticeEventTypeCode = administrationOfJusticeEventTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
