using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMT*OT*j*8*2*7*5*6*4*XP*I";

		var expected = new RMT_RemittanceAdvice()
		{
			ReferenceNumberQualifier = "OT",
			ReferenceNumber = "j",
			MonetaryAmount = 8,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 5,
			MonetaryAmount5 = 6,
			MonetaryAmount6 = 4,
			AdjustmentReasonCode = "XP",
			Description = "I",
		};

		var actual = Map.MapObject<RMT_RemittanceAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OT", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumber = "j";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RMT_RemittanceAdvice();
		subject.ReferenceNumberQualifier = "OT";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
