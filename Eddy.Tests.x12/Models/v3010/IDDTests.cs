using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDD*C*jr*VXNF*d*9*N*aVyS*T*V";

		var expected = new IDD_IncreaseDecreaseDetail()
		{
			TariffItemNumber = "C",
			ConditionSegmentLogicalConnector = "jr",
			ConditionCode = "VXNF",
			ConditionValue = "d",
			ConditionValue2 = "9",
			ConditionValue3 = "N",
			ConditionCode2 = "aVyS",
			ConditionValue4 = "T",
			ConditionValue5 = "V",
		};

		var actual = Map.MapObject<IDD_IncreaseDecreaseDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredTariffItemNumber(string tariffItemNumber, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.ConditionSegmentLogicalConnector = "jr";
		subject.ConditionCode = "VXNF";
		subject.ConditionValue = "d";
		subject.ConditionValue2 = "9";
		subject.ConditionValue3 = "N";
		subject.TariffItemNumber = tariffItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jr", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "C";
		subject.ConditionCode = "VXNF";
		subject.ConditionValue = "d";
		subject.ConditionValue2 = "9";
		subject.ConditionValue3 = "N";
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VXNF", true)]
	public void Validation_RequiredConditionCode(string conditionCode, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "C";
		subject.ConditionSegmentLogicalConnector = "jr";
		subject.ConditionValue = "d";
		subject.ConditionValue2 = "9";
		subject.ConditionValue3 = "N";
		subject.ConditionCode = conditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredConditionValue(string conditionValue, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "C";
		subject.ConditionSegmentLogicalConnector = "jr";
		subject.ConditionCode = "VXNF";
		subject.ConditionValue2 = "9";
		subject.ConditionValue3 = "N";
		subject.ConditionValue = conditionValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredConditionValue2(string conditionValue2, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "C";
		subject.ConditionSegmentLogicalConnector = "jr";
		subject.ConditionCode = "VXNF";
		subject.ConditionValue = "d";
		subject.ConditionValue3 = "N";
		subject.ConditionValue2 = conditionValue2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredConditionValue3(string conditionValue3, bool isValidExpected)
	{
		var subject = new IDD_IncreaseDecreaseDetail();
		subject.TariffItemNumber = "C";
		subject.ConditionSegmentLogicalConnector = "jr";
		subject.ConditionCode = "VXNF";
		subject.ConditionValue = "d";
		subject.ConditionValue2 = "9";
		subject.ConditionValue3 = conditionValue3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
