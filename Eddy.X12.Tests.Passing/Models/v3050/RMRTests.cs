using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RMRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RMR*ly*A*ML*5*9*5";

		var expected = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference()
		{
			ReferenceNumberQualifier = "ly",
			ReferenceNumber = "A",
			PaymentActionCode = "ML",
			MonetaryAmount = 5,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 5,
		};

		var actual = Map.MapObject<RMR_RemittanceAdviceAccountsReceivableOpenItemReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ly", "A", true)]
	[InlineData("ly", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new RMR_RemittanceAdviceAccountsReceivableOpenItemReference();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
