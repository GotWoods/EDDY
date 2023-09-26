using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*ZY*dr*t*Gy7lrg*8*J*4*Wyz*y*2*vJ";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "ZY",
			ReferenceNumberQualifier = "dr",
			ReferenceNumber = "t",
			Date = "Gy7lrg",
			Week = 8,
			MarketAreaCodeQualifier = "J",
			MarketAreaCodeIdentifier = "4",
			CurrencyCode = "Wyz",
			MarketProfile = "y",
			ContractNumber = "2",
			TransactionSetPurposeCode = "vJ",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZY", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.ReferenceNumberQualifier = "dr";
		subject.ReferenceNumber = "t";
		subject.Date = "Gy7lrg";
		subject.Week = 8;
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "J";
			subject.MarketAreaCodeIdentifier = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dr", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ZY";
		subject.ReferenceNumber = "t";
		subject.Date = "Gy7lrg";
		subject.Week = 8;
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "J";
			subject.MarketAreaCodeIdentifier = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ZY";
		subject.ReferenceNumberQualifier = "dr";
		subject.Date = "Gy7lrg";
		subject.Week = 8;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "J";
			subject.MarketAreaCodeIdentifier = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gy7lrg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ZY";
		subject.ReferenceNumberQualifier = "dr";
		subject.ReferenceNumber = "t";
		subject.Week = 8;
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "J";
			subject.MarketAreaCodeIdentifier = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ZY";
		subject.ReferenceNumberQualifier = "dr";
		subject.ReferenceNumber = "t";
		subject.Date = "Gy7lrg";
		//Test Parameters
		if (week > 0) 
			subject.Week = week;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeQualifier) || !string.IsNullOrEmpty(subject.MarketAreaCodeIdentifier))
		{
			subject.MarketAreaCodeQualifier = "J";
			subject.MarketAreaCodeIdentifier = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "4", true)]
	[InlineData("J", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		//Required fields
		subject.TransactionTypeCode = "ZY";
		subject.ReferenceNumberQualifier = "dr";
		subject.ReferenceNumber = "t";
		subject.Date = "Gy7lrg";
		subject.Week = 8;
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
