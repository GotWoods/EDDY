using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:It";

		var expected = new S005_RecipientsReferencePassword()
		{
			RecipientsReferencePassword = "Y",
			RecipientsReferencePasswordQualifier = "It",
		};

		var actual = Map.MapComposite<S005_RecipientsReferencePassword>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRecipientsReferencePassword(string recipientsReferencePassword, bool isValidExpected)
	{
		var subject = new S005_RecipientsReferencePassword();
		//Required fields
		//Test Parameters
		subject.RecipientsReferencePassword = recipientsReferencePassword;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
