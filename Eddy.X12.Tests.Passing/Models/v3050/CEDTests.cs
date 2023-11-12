using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CED*9*h*n*I*s";

		var expected = new CED_CourtEventDescription()
		{
			CourtEventTypeCode = "9",
			ActionCode = "h",
			NoticeTypeCode = "n",
			CaseTypeCode = "I",
			Description = "s",
		};

		var actual = Map.MapObject<CED_CourtEventDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredCourtEventTypeCode(string courtEventTypeCode, bool isValidExpected)
	{
		var subject = new CED_CourtEventDescription();
		//Required fields
		//Test Parameters
		subject.CourtEventTypeCode = courtEventTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
