using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RO*tQ*1e*C*6*1*Gz*XF*4*rJ";

		var expected = new RO_PublicRecordOrObligation()
		{
			PublicRecordOrObligationCode = "tQ",
			DispositionStatusCode = "1e",
			ReferenceIdentification = "C",
			AmountQualifierCode = "6",
			MonetaryAmount = 1,
			RateValueQualifier = "Gz",
			ReferenceIdentificationQualifier = "XF",
			ReferenceIdentification2 = "4",
			TypeOfAccountCode = "rJ",
		};

		var actual = Map.MapObject<RO_PublicRecordOrObligation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tQ", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		//Required fields
		//Test Parameters
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "6";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "XF";
			subject.ReferenceIdentification2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 1, true)]
	[InlineData("6", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		//Required fields
		subject.PublicRecordOrObligationCode = "tQ";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//A Requires B
		if (monetaryAmount > 0)
			subject.RateValueQualifier = "Gz";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "XF";
			subject.ReferenceIdentification2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Gz", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Gz", true)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		//Required fields
		subject.PublicRecordOrObligationCode = "tQ";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "6";
			subject.MonetaryAmount = 1;
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier = "XF";
			subject.ReferenceIdentification2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XF", "4", true)]
	[InlineData("XF", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RO_PublicRecordOrObligation();
		//Required fields
		subject.PublicRecordOrObligationCode = "tQ";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "6";
			subject.MonetaryAmount = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
