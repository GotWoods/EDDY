using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:J:I";

		var expected = new S003_InterchangeRecipient()
		{
			RecipientIdentification = "S",
			PartnerIdentificationCodeQualifier = "J",
			RoutingAddress = "I",
		};

		var actual = Map.MapComposite<S003_InterchangeRecipient>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredRecipientIdentification(string recipientIdentification, bool isValidExpected)
	{
		var subject = new S003_InterchangeRecipient();
		//Required fields
		//Test Parameters
		subject.RecipientIdentification = recipientIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
