using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SVDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVD*w*5**y*9*9";

		var expected = new SVD_ServiceLineAdjudication()
		{
			PayerResponsibilitySequenceNumberCode = "w",
			MonetaryAmount = 5,
			CompositeMedicalProcedureIdentifier = null,
			ProductServiceID = "y",
			Quantity = 9,
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<SVD_ServiceLineAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SVD_ServiceLineAdjudication();
		subject.MonetaryAmount = 5;
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SVD_ServiceLineAdjudication();
		subject.PayerResponsibilitySequenceNumberCode = "w";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
