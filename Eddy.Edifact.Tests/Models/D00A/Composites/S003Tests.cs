using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:7:G:v";

		var expected = new S003_InterchangeRecipient()
		{
			InterchangeRecipientIdentification = "5",
			IdentificationCodeQualifier = "7",
			InterchangeRecipientInternalIdentification = "G",
			InterchangeRecipientInternalSubIdentification = "v",
		};

		var actual = Map.MapComposite<S003_InterchangeRecipient>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredInterchangeRecipientIdentification(string interchangeRecipientIdentification, bool isValidExpected)
	{
		var subject = new S003_InterchangeRecipient();
		//Required fields
		//Test Parameters
		subject.InterchangeRecipientIdentification = interchangeRecipientIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
