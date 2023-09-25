using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ADXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADX*4*Bx*4u*7";

		var expected = new ADX_Adjustment()
		{
			MonetaryAmount = 4,
			AdjustmentReasonCode = "Bx",
			ReferenceNumberQualifier = "4u",
			ReferenceNumber = "7",
		};

		var actual = Map.MapObject<ADX_Adjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ADX_Adjustment();
		//Required fields
		subject.AdjustmentReasonCode = "Bx";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bx", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new ADX_Adjustment();
		//Required fields
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "4u", true)]
	[InlineData("7", "", false)]
	[InlineData("", "4u", true)]
	public void Validation_ARequiresBReferenceNumber(string referenceNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new ADX_Adjustment();
		//Required fields
		subject.MonetaryAmount = 4;
		subject.AdjustmentReasonCode = "Bx";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
