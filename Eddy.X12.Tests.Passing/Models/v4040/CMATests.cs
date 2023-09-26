using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*79*qc*1*S6kumlv7*218852*3*w*aDJ*L*Q*cF";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "79",
			ReferenceIdentificationQualifier = "qc",
			ReferenceIdentification = "1",
			Date = "S6kumlv7",
			Week = 218852,
			MarketAreaCodeQualifier = "3",
			MarketAreaCodeIdentifier = "w",
			CurrencyCode = "aDJ",
			MarketProfile = "L",
			ContractNumber = "Q",
			TransactionSetPurposeCode = "cF",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("79", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.ReferenceIdentificationQualifier = "qc";
		subject.ReferenceIdentification = "1";
		subject.Date = "S6kumlv7";
		subject.Week = 218852;
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "3";
			subject.MarketAreaCodeIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qc", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "79";
		subject.ReferenceIdentification = "1";
		subject.Date = "S6kumlv7";
		subject.Week = 218852;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "3";
			subject.MarketAreaCodeIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "79";
		subject.ReferenceIdentificationQualifier = "qc";
		subject.Date = "S6kumlv7";
		subject.Week = 218852;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "3";
			subject.MarketAreaCodeIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S6kumlv7", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "79";
		subject.ReferenceIdentificationQualifier = "qc";
		subject.ReferenceIdentification = "1";
		subject.Week = 218852;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "3";
			subject.MarketAreaCodeIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(218852, true)]
	public void Validation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "79";
		subject.ReferenceIdentificationQualifier = "qc";
		subject.ReferenceIdentification = "1";
		subject.Date = "S6kumlv7";
		//Test Parameters
		if (week > 0) 
			subject.Week = week;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "3";
			subject.MarketAreaCodeIdentifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "w", true)]
	[InlineData("3", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "79";
		subject.ReferenceIdentificationQualifier = "qc";
		subject.ReferenceIdentification = "1";
		subject.Date = "S6kumlv7";
		subject.Week = 218852;
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
