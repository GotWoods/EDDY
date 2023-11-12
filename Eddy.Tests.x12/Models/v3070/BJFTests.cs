using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BJFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BJF*BZ*tB*J*Xx4t0E*fa*qd";

		var expected = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity()
		{
			TransactionSetPurposeCode = "BZ",
			TransactionTypeCode = "tB",
			Rule260JunctionCode = "J",
			StandardPointLocationCode = "Xx4t0E",
			CityName = "fa",
			StateOrProvinceCode = "qd",
		};

		var actual = Map.MapObject<BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionTypeCode = "tB";
		subject.Rule260JunctionCode = "J";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "fa";
			subject.StateOrProvinceCode = "qd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tB", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "BZ";
		subject.Rule260JunctionCode = "J";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "fa";
			subject.StateOrProvinceCode = "qd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredRule260JunctionCode(string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "BZ";
		subject.TransactionTypeCode = "tB";
		//Test Parameters
		subject.Rule260JunctionCode = rule260JunctionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "fa";
			subject.StateOrProvinceCode = "qd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fa", "qd", true)]
	[InlineData("fa", "", false)]
	[InlineData("", "qd", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "BZ";
		subject.TransactionTypeCode = "tB";
		subject.Rule260JunctionCode = "J";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
