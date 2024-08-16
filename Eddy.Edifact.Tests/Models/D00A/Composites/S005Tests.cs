using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:U4";

		var expected = new S005_RecipientReferencePasswordDetails()
		{
			RecipientReferencePassword = "T",
			RecipientReferencePasswordQualifier = "U4",
		};

		var actual = Map.MapComposite<S005_RecipientReferencePasswordDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredRecipientReferencePassword(string recipientReferencePassword, bool isValidExpected)
	{
		var subject = new S005_RecipientReferencePasswordDetails();
		//Required fields
		//Test Parameters
		subject.RecipientReferencePassword = recipientReferencePassword;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
