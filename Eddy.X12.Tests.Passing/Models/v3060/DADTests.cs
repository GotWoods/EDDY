using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAD*M*A*Zv9Gpw*CN8mP7*0JddAURuzX*d6AwTO4P6*L*4*7*Y*7A*IPI*u*3*d";

		var expected = new DAD_DebitAuthorizationDetail()
		{
			ActionCode = "M",
			TransactionHandlingCode = "A",
			Date = "Zv9Gpw",
			Date2 = "CN8mP7",
			OriginatingCompanyIdentifier = "0JddAURuzX",
			OriginatingCompanySupplementalCode = "d6AwTO4P6",
			AmountQualifierCode = "L",
			MonetaryAmount = 4,
			ReferenceIdentification = "7",
			ReferenceIdentification2 = "Y",
			DFIIDNumberQualifier = "7A",
			DFIIdentificationNumber = "IPI",
			AccountNumber = "u",
			Number = 3,
			FrequencyCode = "d",
		};

		var actual = Map.MapObject<DAD_DebitAuthorizationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.TransactionHandlingCode = "A";
		subject.Date = "Zv9Gpw";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "L";
			subject.MonetaryAmount = 4;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "7A";
			subject.DFIIdentificationNumber = "IPI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "M";
		subject.Date = "Zv9Gpw";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "L";
			subject.MonetaryAmount = 4;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "7A";
			subject.DFIIdentificationNumber = "IPI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zv9Gpw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "M";
		subject.TransactionHandlingCode = "A";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "L";
			subject.MonetaryAmount = 4;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "7A";
			subject.DFIIdentificationNumber = "IPI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("L", 4, true)]
	[InlineData("L", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "M";
		subject.TransactionHandlingCode = "A";
		subject.Date = "Zv9Gpw";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "7A";
			subject.DFIIdentificationNumber = "IPI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "7", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string referenceIdentification, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "M";
		subject.TransactionHandlingCode = "A";
		subject.Date = "Zv9Gpw";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "L";
			subject.MonetaryAmount = 4;
		}
		if(!string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIDNumberQualifier) || !string.IsNullOrEmpty(subject.DFIIdentificationNumber))
		{
			subject.DFIIDNumberQualifier = "7A";
			subject.DFIIdentificationNumber = "IPI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7A", "IPI", true)]
	[InlineData("7A", "", false)]
	[InlineData("", "IPI", false)]
	public void Validation_AllAreRequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DAD_DebitAuthorizationDetail();
		//Required fields
		subject.ActionCode = "M";
		subject.TransactionHandlingCode = "A";
		subject.Date = "Zv9Gpw";
		//Test Parameters
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "L";
			subject.MonetaryAmount = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
