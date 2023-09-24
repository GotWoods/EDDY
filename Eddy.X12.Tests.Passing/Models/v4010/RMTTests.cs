using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*oe*l*9*8*1*2*2*7*aH*t";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceIdentificationQualifier = "oe",
			ReferenceIdentification = "l",
			MonetaryAmount = 9,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 1,
			MonetaryAmount4 = 2,
			MonetaryAmount5 = 2,
			MonetaryAmount6 = 7,
			AdjustmentReasonCode = "aH",
			Description = "t",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oe", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentification = "l";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentificationQualifier = "oe";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
