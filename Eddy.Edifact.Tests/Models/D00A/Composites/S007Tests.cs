using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:p";

		var expected = new S007_ApplicationRecipientIdentification()
		{
			ApplicationRecipientIdentification = "d",
			IdentificationCodeQualifier = "p",
		};

		var actual = Map.MapComposite<S007_ApplicationRecipientIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredApplicationRecipientIdentification(string applicationRecipientIdentification, bool isValidExpected)
	{
		var subject = new S007_ApplicationRecipientIdentification();
		//Required fields
		//Test Parameters
		subject.ApplicationRecipientIdentification = applicationRecipientIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
