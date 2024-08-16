using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S006Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:4";

		var expected = new S006_ApplicationSenderIdentification()
		{
			ApplicationSenderIdentification = "w",
			IdentificationCodeQualifier = "4",
		};

		var actual = Map.MapComposite<S006_ApplicationSenderIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredApplicationSenderIdentification(string applicationSenderIdentification, bool isValidExpected)
	{
		var subject = new S006_ApplicationSenderIdentification();
		//Required fields
		//Test Parameters
		subject.ApplicationSenderIdentification = applicationSenderIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
