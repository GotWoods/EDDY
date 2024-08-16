using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S006Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:O";

		var expected = new S006_ApplicationSendersIdentification()
		{
			SenderIdentification = "Y",
			PartnerIdentificationCodeQualifier = "O",
		};

		var actual = Map.MapComposite<S006_ApplicationSendersIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredSenderIdentification(string senderIdentification, bool isValidExpected)
	{
		var subject = new S006_ApplicationSendersIdentification();
		//Required fields
		//Test Parameters
		subject.SenderIdentification = senderIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
