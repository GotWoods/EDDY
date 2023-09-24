using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*0j*w*2*9*9*6*7*4*MV*d";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceIdentificationQualifier = "0j",
			ReferenceIdentification = "w",
			MonetaryAmount = 2,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 9,
			MonetaryAmount4 = 6,
			MonetaryAmount5 = 7,
			MonetaryAmount6 = 4,
			AdjustmentReasonCode = "MV",
			Description = "d",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0j", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceIdentificationQualifier = "0j";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
