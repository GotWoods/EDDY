using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CMA*Gl*pY*r*pekdfZ0K*151965*X*V*PxK*F*2*lv";

		var expected = new CMA_CooperativeMarketAgreement()
		{
			TransactionTypeCode = "Gl",
			ReferenceIdentificationQualifier = "pY",
			ReferenceIdentification = "r",
			Date = "pekdfZ0K",
			Week = 151965,
			MarketAreaCodeQualifier = "X",
			MarketAreaCodeIdentifier = "V",
			CurrencyCode = "PxK",
			MarketProfile = "F",
			ContractNumber = "2",
			TransactionSetPurposeCode = "lv",
		};

		var actual = Map.MapObject<CMA_CooperativeMarketAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gl", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.ReferenceIdentificationQualifier = "pY";
		subject.ReferenceIdentification = "r";
		subject.Date = "pekdfZ0K";
		subject.Week = 151965;
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pY", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.TransactionTypeCode = "Gl";
		subject.ReferenceIdentification = "r";
		subject.Date = "pekdfZ0K";
		subject.Week = 151965;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.TransactionTypeCode = "Gl";
		subject.ReferenceIdentificationQualifier = "pY";
		subject.Date = "pekdfZ0K";
		subject.Week = 151965;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pekdfZ0K", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.TransactionTypeCode = "Gl";
		subject.ReferenceIdentificationQualifier = "pY";
		subject.ReferenceIdentification = "r";
		subject.Week = 151965;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(151965, true)]
	public void Validatation_RequiredWeek(int week, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.TransactionTypeCode = "Gl";
		subject.ReferenceIdentificationQualifier = "pY";
		subject.ReferenceIdentification = "r";
		subject.Date = "pekdfZ0K";
		if (week > 0)
		subject.Week = week;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("X", "V", true)]
	[InlineData("", "V", false)]
	[InlineData("X", "", false)]
	public void Validation_AllAreRequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, bool isValidExpected)
	{
		var subject = new CMA_CooperativeMarketAgreement();
		subject.TransactionTypeCode = "Gl";
		subject.ReferenceIdentificationQualifier = "pY";
		subject.ReferenceIdentification = "r";
		subject.Date = "pekdfZ0K";
		subject.Week = 151965;
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
