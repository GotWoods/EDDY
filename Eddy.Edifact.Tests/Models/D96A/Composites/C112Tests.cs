using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C112Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:F:i:e";

		var expected = new C112_TermsTimeInformation()
		{
			PaymentTimeReferenceCoded = "9",
			TimeRelationCoded = "F",
			TypeOfPeriodCoded = "i",
			NumberOfPeriods = "e",
		};

		var actual = Map.MapComposite<C112_TermsTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredPaymentTimeReferenceCoded(string paymentTimeReferenceCoded, bool isValidExpected)
	{
		var subject = new C112_TermsTimeInformation();
		//Required fields
		//Test Parameters
		subject.PaymentTimeReferenceCoded = paymentTimeReferenceCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
