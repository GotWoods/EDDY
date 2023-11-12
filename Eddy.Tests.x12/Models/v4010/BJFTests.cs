using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BJFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BJF*Ls*bQ*r*iwutK1*Hj*MG*ic";

		var expected = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity()
		{
			TransactionSetPurposeCode = "Ls",
			TransactionTypeCode = "bQ",
			Rule260JunctionCode = "r",
			StandardPointLocationCode = "iwutK1",
			CityName = "Hj",
			StateOrProvinceCode = "MG",
			CountryCode = "ic",
		};

		var actual = Map.MapObject<BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ls", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionTypeCode = "bQ";
		subject.Rule260JunctionCode = "r";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Hj";
			subject.StateOrProvinceCode = "MG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bQ", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "Ls";
		subject.Rule260JunctionCode = "r";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Hj";
			subject.StateOrProvinceCode = "MG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredRule260JunctionCode(string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "Ls";
		subject.TransactionTypeCode = "bQ";
		//Test Parameters
		subject.Rule260JunctionCode = rule260JunctionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Hj";
			subject.StateOrProvinceCode = "MG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hj", "MG", true)]
	[InlineData("Hj", "", false)]
	[InlineData("", "MG", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "Ls";
		subject.TransactionTypeCode = "bQ";
		subject.Rule260JunctionCode = "r";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
