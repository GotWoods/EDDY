using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IA*5*A*SK*DE*uS*Rd*Gq";

		var expected = new IA_InterconnectMailbagAcknowledgment()
		{
			InterconnectMailbagControlNumber = 5,
			InterconnectMailbagAcknowledgmentActionCode = "A",
			InterconnectMailbagErrorCode = "SK",
			InterconnectMailbagErrorCode2 = "DE",
			InterconnectMailbagErrorCode3 = "uS",
			InterconnectMailbagErrorCode4 = "Rd",
			InterconnectMailbagErrorCode5 = "Gq",
		};

		var actual = Map.MapObject<IA_InterconnectMailbagAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IA_InterconnectMailbagAcknowledgment();
		subject.InterconnectMailbagAcknowledgmentActionCode = "A";
		if (interconnectMailbagControlNumber > 0)
		subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterconnectMailbagAcknowledgmentActionCode(string interconnectMailbagAcknowledgmentActionCode, bool isValidExpected)
	{
		var subject = new IA_InterconnectMailbagAcknowledgment();
		subject.InterconnectMailbagControlNumber = 5;
		subject.InterconnectMailbagAcknowledgmentActionCode = interconnectMailbagAcknowledgmentActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
