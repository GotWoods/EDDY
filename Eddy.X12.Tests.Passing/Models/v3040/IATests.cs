using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IA*4*c*Im*uQ*Vg*Jm*MR";

		var expected = new IA_InterconnectMailbagAcknowledgment()
		{
			InterconnectMailbagControlNumber = 4,
			InterconnectMailbagAcknowledgmentActionCode = "c",
			InterconnectMailbagErrorCode = "Im",
			InterconnectMailbagErrorCode2 = "uQ",
			InterconnectMailbagErrorCode3 = "Vg",
			InterconnectMailbagErrorCode4 = "Jm",
			InterconnectMailbagErrorCode5 = "MR",
		};

		var actual = Map.MapObject<IA_InterconnectMailbagAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IA_InterconnectMailbagAcknowledgment();
		//Required fields
		subject.InterconnectMailbagAcknowledgmentActionCode = "c";
		//Test Parameters
		if (interconnectMailbagControlNumber > 0) 
			subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredInterconnectMailbagAcknowledgmentActionCode(string interconnectMailbagAcknowledgmentActionCode, bool isValidExpected)
	{
		var subject = new IA_InterconnectMailbagAcknowledgment();
		//Required fields
		subject.InterconnectMailbagControlNumber = 4;
		//Test Parameters
		subject.InterconnectMailbagAcknowledgmentActionCode = interconnectMailbagAcknowledgmentActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
