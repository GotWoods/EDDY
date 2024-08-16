using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:3:h";

		var expected = new S002_InterchangeSender()
		{
			SenderIdentification = "b",
			PartnerIdentificationCodeQualifier = "3",
			AddressForReverseRouting = "h",
		};

		var actual = Map.MapComposite<S002_InterchangeSender>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredSenderIdentification(string senderIdentification, bool isValidExpected)
	{
		var subject = new S002_InterchangeSender();
		//Required fields
		//Test Parameters
		subject.SenderIdentification = senderIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
