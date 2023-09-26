using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CED*T*d*0*x*t";

		var expected = new CED_AdministrationOfJusticeEventDescription()
		{
			AdministrationOfJusticeEventTypeCode = "T",
			ActionCode = "d",
			NoticeTypeCode = "0",
			CaseTypeCode = "x",
			Description = "t",
		};

		var actual = Map.MapObject<CED_AdministrationOfJusticeEventDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAdministrationOfJusticeEventTypeCode(string administrationOfJusticeEventTypeCode, bool isValidExpected)
	{
		var subject = new CED_AdministrationOfJusticeEventDescription();
		//Required fields
		//Test Parameters
		subject.AdministrationOfJusticeEventTypeCode = administrationOfJusticeEventTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
