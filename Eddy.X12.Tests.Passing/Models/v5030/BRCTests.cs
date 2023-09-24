using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRC*XX*nv5K7a7C*A5*A*Q6F3";

		var expected = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "XX",
			Date = "nv5K7a7C",
			ReferenceIdentificationQualifier = "A5",
			ReferenceIdentification = "A",
			Time = "Q6F3",
		};

		var actual = Map.MapObject<BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XX", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.Date = "nv5K7a7C";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "A5";
			subject.ReferenceIdentification = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nv5K7a7C", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "XX";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "A5";
			subject.ReferenceIdentification = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A5", "A", true)]
	[InlineData("A5", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "XX";
		subject.Date = "nv5K7a7C";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
