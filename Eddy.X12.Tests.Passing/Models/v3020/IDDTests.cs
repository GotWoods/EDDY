using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDD*6*0d*KMRc*c*1*4*UNe1*u*z";

		var expected = new IDD_IncreaseDecreaseDetail()
		{
			TariffItemNumber = "6",
			ConditionSegmentLogicalConnector = "0d",
			ConditionCode = "KMRc",
			ConditionValue = "c",
			ConditionValue2 = "1",
			ConditionValue3 = "4",
			ConditionCode2 = "UNe1",
			ConditionValue4 = "u",
			ConditionValue5 = "z",
		};

		var actual = Map.MapObject<IDD_IncreaseDecreaseDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredTariffItemNumber(string tariffItemNumber, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue = "c";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = "4";
		subject.TariffItemNumber = tariffItemNumber;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0d", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue = "c";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = "4";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KMRc", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionValue = "c";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = "4";
		subject.ConditionCode = conditionCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = "4";
		subject.ConditionValue = conditionValue;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredConditionValue2(string conditionValue2, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue = "c";
		subject.ConditionValue3 = "4";
		subject.ConditionValue2 = conditionValue2;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredConditionValue3(string conditionValue3, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue = "c";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = conditionValue3;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionCode2) || !string.IsNullOrEmpty(subject.ConditionValue4) || !string.IsNullOrEmpty(subject.ConditionValue5))
		{
			subject.ConditionCode2 = "UNe1";
			subject.ConditionValue4 = "u";
			subject.ConditionValue5 = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("UNe1", "u", "z", true)]
	[InlineData("UNe1", "", "", false)]
	[InlineData("", "u", "z", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ConditionCode2(string conditionCode2, string conditionValue4, string conditionValue5, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "6";
		subject.ConditionSegmentLogicalConnector = "0d";
		subject.ConditionCode = "KMRc";
		subject.ConditionValue = "c";
		subject.ConditionValue2 = "1";
		subject.ConditionValue3 = "4";
		subject.ConditionCode2 = conditionCode2;
		subject.ConditionValue4 = conditionValue4;
		subject.ConditionValue5 = conditionValue5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
