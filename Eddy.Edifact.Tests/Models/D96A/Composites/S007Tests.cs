using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:H";

		var expected = new S007_ApplicationRecipientsIdentification()
		{
			RecipientsIdentification = "r",
			PartnerIdentificationCodeQualifier = "H",
		};

		var actual = Map.MapComposite<S007_ApplicationRecipientsIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredRecipientsIdentification(string recipientsIdentification, bool isValidExpected)
	{
		var subject = new S007_ApplicationRecipientsIdentification();
		//Required fields
		//Test Parameters
		subject.RecipientsIdentification = recipientsIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
