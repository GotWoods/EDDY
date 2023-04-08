using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AAA*k*Uy*Az*u*Yl";

		var expected = new AAA_RequestValidation()
		{
	YesNoConditionOrResponseCode = "k",
	AgencyQualifierCode = "Uy",
	RejectReasonCode = "Az",
	FollowUpActionCode = "u",
	ErrorReasonCode = "Yl",
	};

	var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithTilde);
	Assert.Equivalent(expected, actual);
	}
[Theory]
[InlineData("", false)]
[InlineData("k", true)]
public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
{
var subject = new AAA_RequestValidation();
subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
}
}
