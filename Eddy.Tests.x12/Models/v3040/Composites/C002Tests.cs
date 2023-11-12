using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040;
using Eddy.x12.Models.v3040.Composites;

namespace Eddy.x12.Tests.Models.v3040.Composites;

public class C002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Y*p*p*x*f";

		var expected = new C002_ActionsIndicated()
		{
			PaperworkReportActionCode = "Y",
			PaperworkReportActionCode2 = "p",
			PaperworkReportActionCode3 = "p",
			PaperworkReportActionCode4 = "x",
			PaperworkReportActionCode5 = "f",
		};

		var actual = Map.MapObject<C002_ActionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredPaperworkReportActionCode(string paperworkReportActionCode, bool isValidExpected)
	{
		var subject = new C002_ActionsIndicated();
		//Required fields
		//Test Parameters
		subject.PaperworkReportActionCode = paperworkReportActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
