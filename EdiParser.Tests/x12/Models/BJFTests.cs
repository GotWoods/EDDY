using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BJFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BJF*ap*A7*y*UxUKuO*6W*Y6*6I";

		var expected = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity()
		{
			TransactionSetPurposeCode = "ap",
			TransactionTypeCode = "A7",
			Rule260JunctionCode = "y",
			StandardPointLocationCode = "UxUKuO",
			CityName = "6W",
			StateOrProvinceCode = "Y6",
			CountryCode = "6I",
		};

		var actual = Map.MapObject<BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ap", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		subject.TransactionTypeCode = "A7";
		subject.Rule260JunctionCode = "y";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A7", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		subject.TransactionSetPurposeCode = "ap";
		subject.Rule260JunctionCode = "y";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validatation_RequiredRule260JunctionCode(string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		subject.TransactionSetPurposeCode = "ap";
		subject.TransactionTypeCode = "A7";
		subject.Rule260JunctionCode = rule260JunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6W", "Y6", true)]
	[InlineData("", "Y6", false)]
	[InlineData("6W", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		subject.TransactionSetPurposeCode = "ap";
		subject.TransactionTypeCode = "A7";
		subject.Rule260JunctionCode = "y";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
