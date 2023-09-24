using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*ST*c*9*9*9*1*3*1*Q0*F";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceIdentificationQualifier = "ST",
			ReferenceIdentification = "c",
			MonetaryAmount = 9,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 9,
			MonetaryAmount4 = 1,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 1,
			AdjustmentReasonCode = "Q0",
			Description = "F",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ST", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentificationQualifier = "ST";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
