using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*ou*u2*g*QaxoqlIO*257852*x*k*Jga*p*y*Oj";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "ou",
			ReferenceIdentificationQualifier = "u2",
			ReferenceIdentification = "g",
			Date = "QaxoqlIO",
			Week = 257852,
			MarketAreaCodeQualifier = "x",
			MarketAreaCodeIdentifier = "k",
			CurrencyCode = "Jga",
			MarketProfile = "p",
			ContractNumber = "y",
			TransactionSetPurposeCode = "Oj",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ou", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.ReferenceIdentificationQualifier = "u2";
		subject.ReferenceIdentification = "g";
		subject.Date = "QaxoqlIO";
		subject.Week = 257852;
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "x";
			subject.MarketAreaCodeIdentifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u2", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ou";
		subject.ReferenceIdentification = "g";
		subject.Date = "QaxoqlIO";
		subject.Week = 257852;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "x";
			subject.MarketAreaCodeIdentifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ou";
		subject.ReferenceIdentificationQualifier = "u2";
		subject.Date = "QaxoqlIO";
		subject.Week = 257852;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "x";
			subject.MarketAreaCodeIdentifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QaxoqlIO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ou";
		subject.ReferenceIdentificationQualifier = "u2";
		subject.ReferenceIdentification = "g";
		subject.Week = 257852;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "x";
			subject.MarketAreaCodeIdentifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(257852, true)]
	public void Validation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ou";
		subject.ReferenceIdentificationQualifier = "u2";
		subject.ReferenceIdentification = "g";
		subject.Date = "QaxoqlIO";
		//Test Parameters
		if (week > 0) 
			subject.Week = week;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "x";
			subject.MarketAreaCodeIdentifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "k", true)]
	[InlineData("x", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ou";
		subject.ReferenceIdentificationQualifier = "u2";
		subject.ReferenceIdentification = "g";
		subject.Date = "QaxoqlIO";
		subject.Week = 257852;
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
