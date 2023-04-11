using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*5*9*O*egp*4*xI*CW*Y*gl5YX*X*c*s*qZ8*Va*hgy*v*C*QN*49*C*0Kz*Sx";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 5,
			Quantity = 9,
			ProductServiceID = "O",
			PartName = "egp",
			Amount = "4",
			DamageAreaCode = "xI",
			DamageTypeCode = "CW",
			DamageSeverityCode = "Y",
			LaborOperationIdentifier = "gl5YX",
			FreeFormDescription = "X",
			LaborHours = "c",
			LaborHours2 = "s",
			TotalLaborCost = "qZ8",
			TotalMiscellaneousCosts = "Va",
			TotalRepairCost = "hgy",
			AuthorizationIdentification = "v",
			InspectionLocationTypeCode = "C",
			DamageAreaCode2 = "QN",
			DamageTypeCode2 = "49",
			DamageSeverityCode2 = "C",
			DeclineAmendReasonCode = "0Kz",
			ChargeAllowanceQualifier = "Sx",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validatation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		subject.DamageAreaCode = "xI";
		subject.DamageTypeCode = "CW";
		subject.DamageSeverityCode = "Y";
		subject.TotalRepairCost = "hgy";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xI", true)]
	public void Validatation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		subject.AssignedNumber = 5;
		subject.DamageTypeCode = "CW";
		subject.DamageSeverityCode = "Y";
		subject.TotalRepairCost = "hgy";
		subject.DamageAreaCode = damageAreaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CW", true)]
	public void Validatation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		subject.AssignedNumber = 5;
		subject.DamageAreaCode = "xI";
		subject.DamageSeverityCode = "Y";
		subject.TotalRepairCost = "hgy";
		subject.DamageTypeCode = damageTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validatation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		subject.AssignedNumber = 5;
		subject.DamageAreaCode = "xI";
		subject.DamageTypeCode = "CW";
		subject.TotalRepairCost = "hgy";
		subject.DamageSeverityCode = damageSeverityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}
	//TODO: these tests
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("c", "s", false)]
	// [InlineData("","s", true)]
	// [InlineData("c", "", true)]
	// public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	// {
	// 	var subject = new F07_AutoClaimDetail();
	// 	subject.AssignedNumber = 5;
	// 	subject.DamageAreaCode = "xI";
	// 	subject.DamageTypeCode = "CW";
	// 	subject.DamageSeverityCode = "Y";
	// 	subject.TotalRepairCost = "hgy";
	// 	subject.LaborHours = laborHours;
	// 	subject.LaborHours2 = laborHours2;
	// 	subject.TotalLaborCost = totalLaborCost;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	// }
	//
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("qZ8", "c", false)]
	// [InlineData("","c", true)]
	// [InlineData("qZ8", "", true)]
	// public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	// {
	// 	var subject = new F07_AutoClaimDetail();
	// 	subject.AssignedNumber = 5;
	// 	subject.DamageAreaCode = "xI";
	// 	subject.DamageTypeCode = "CW";
	// 	subject.DamageSeverityCode = "Y";
	// 	subject.TotalRepairCost = "hgy";
	// 	subject.TotalLaborCost = totalLaborCost;
	// 	subject.LaborHours = laborHours;
	// 	subject.LaborHours2 = laborHours2;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	// }

	[Theory]
	[InlineData("", false)]
	[InlineData("hgy", true)]
	public void Validatation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		subject.AssignedNumber = 5;
		subject.DamageAreaCode = "xI";
		subject.DamageTypeCode = "CW";
		subject.DamageSeverityCode = "Y";
		subject.TotalRepairCost = totalRepairCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
