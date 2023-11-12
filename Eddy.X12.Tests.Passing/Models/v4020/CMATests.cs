using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*HD*bt*n*ZEEUPFIA*2547*5*G*AVF*z*5*3B";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "HD",
			ReferenceIdentificationQualifier = "bt",
			ReferenceIdentification = "n",
			Date = "ZEEUPFIA",
			Week = 2547,
			MarketAreaCodeQualifier = "5",
			MarketAreaCodeIdentifier = "G",
			CurrencyCode = "AVF",
			MarketProfile = "z",
			ContractNumber = "5",
			TransactionSetPurposeCode = "3B",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HD", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.ReferenceIdentificationQualifier = "bt";
		subject.ReferenceIdentification = "n";
		subject.Date = "ZEEUPFIA";
		subject.Week = 2547;
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "5";
			subject.MarketAreaCodeIdentifier = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bt", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "HD";
		subject.ReferenceIdentification = "n";
		subject.Date = "ZEEUPFIA";
		subject.Week = 2547;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "5";
			subject.MarketAreaCodeIdentifier = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "HD";
		subject.ReferenceIdentificationQualifier = "bt";
		subject.Date = "ZEEUPFIA";
		subject.Week = 2547;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "5";
			subject.MarketAreaCodeIdentifier = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZEEUPFIA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "HD";
		subject.ReferenceIdentificationQualifier = "bt";
		subject.ReferenceIdentification = "n";
		subject.Week = 2547;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "5";
			subject.MarketAreaCodeIdentifier = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2547, true)]
	public void Validation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "HD";
		subject.ReferenceIdentificationQualifier = "bt";
		subject.ReferenceIdentification = "n";
		subject.Date = "ZEEUPFIA";
		//Test Parameters
		if (week > 0) 
			subject.Week = week;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "5";
			subject.MarketAreaCodeIdentifier = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "G", true)]
	[InlineData("5", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "HD";
		subject.ReferenceIdentificationQualifier = "bt";
		subject.ReferenceIdentification = "n";
		subject.Date = "ZEEUPFIA";
		subject.Week = 2547;
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
