using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RO*tO*PI*y*N*4*FH*Dl*q*os";

		var expected = new RO_PublicRecordOrObligation()
		{
			PublicRecordOrObligationCode = "tO",
			DispositionStatusCode = "PI",
			ReferenceIdentification = "y",
			AmountQualifierCode = "N",
			MonetaryAmount = 4,
			RateValueQualifier = "FH",
			ReferenceIdentificationQualifier = "Dl",
			ReferenceIdentification2 = "q",
			TypeOfAccountCode = "os",
		};

		var actual = Map.MapObject<RO_PublicRecordOrObligation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tO", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("N", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("N", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		subject.PublicRecordOrObligationCode = "tO";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "FH", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		subject.PublicRecordOrObligationCode = "tO";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Dl", "q", true)]
	[InlineData("", "q", false)]
	[InlineData("Dl", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		subject.PublicRecordOrObligationCode = "tO";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
