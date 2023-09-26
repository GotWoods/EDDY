using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*Nf*4Y*U*Zlp7Qy*1393*q*v*zqX*c*g*f2";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "Nf",
			ReferenceIdentificationQualifier = "4Y",
			ReferenceIdentification = "U",
			Date = "Zlp7Qy",
			Week = 1393,
			MarketAreaCodeQualifier = "q",
			MarketAreaCodeIdentifier = "v",
			CurrencyCode = "zqX",
			MarketProfile = "c",
			ContractNumber = "g",
			TransactionSetPurposeCode = "f2",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nf", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4Y";
		subject.ReferenceIdentification = "U";
		subject.Date = "Zlp7Qy";
		subject.Week = 1393;
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "q";
			subject.MarketAreaCodeIdentifier = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Y", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "Nf";
		subject.ReferenceIdentification = "U";
		subject.Date = "Zlp7Qy";
		subject.Week = 1393;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "q";
			subject.MarketAreaCodeIdentifier = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "Nf";
		subject.ReferenceIdentificationQualifier = "4Y";
		subject.Date = "Zlp7Qy";
		subject.Week = 1393;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "q";
			subject.MarketAreaCodeIdentifier = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zlp7Qy", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "Nf";
		subject.ReferenceIdentificationQualifier = "4Y";
		subject.ReferenceIdentification = "U";
		subject.Week = 1393;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "q";
			subject.MarketAreaCodeIdentifier = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1393, true)]
	public void Validation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "Nf";
		subject.ReferenceIdentificationQualifier = "4Y";
		subject.ReferenceIdentification = "U";
		subject.Date = "Zlp7Qy";
		//Test Parameters
		if (week > 0) 
			subject.Week = week;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "q";
			subject.MarketAreaCodeIdentifier = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "v", true)]
	[InlineData("q", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "Nf";
		subject.ReferenceIdentificationQualifier = "4Y";
		subject.ReferenceIdentification = "U";
		subject.Date = "Zlp7Qy";
		subject.Week = 1393;
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
