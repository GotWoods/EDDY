using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:9:t:4";

		var expected = new S002_InterchangeSender()
		{
			InterchangeSenderIdentification = "B",
			IdentificationCodeQualifier = "9",
			InterchangeSenderInternalIdentification = "t",
			InterchangeSenderInternalSubIdentification = "4",
		};

		var actual = Map.MapComposite<S002_InterchangeSender>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredInterchangeSenderIdentification(string interchangeSenderIdentification, bool isValidExpected)
	{
		var subject = new S002_InterchangeSender();
		//Required fields
		//Test Parameters
		subject.InterchangeSenderIdentification = interchangeSenderIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
