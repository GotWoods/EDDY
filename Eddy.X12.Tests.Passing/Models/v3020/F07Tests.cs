using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*3*5*e*Au2*q*Yv*z9*R*LxvTs*O*1*d*r4t*F6*7Tg*n*0*tU*3e*c*h8s*b6";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 3,
			Quantity = 5,
			ProductServiceID = "e",
			PartName = "Au2",
			Amount = "q",
			DamageAreaCode = "Yv",
			DamageTypeCode = "z9",
			DamageSeverityCode = "R",
			LaborOperationIdentifier = "LxvTs",
			FreeFormDescription = "O",
			LaborHours = "1",
			LaborHours2 = "d",
			TotalLaborCost = "r4t",
			TotalMiscellaneousCosts = "F6",
			TotalRepairCost = "7Tg",
			AuthorizationIdentification = "n",
			InspectionLocationTypeCode = "0",
			DamageAreaCode2 = "tU",
			DamageTypeCode2 = "3e",
			DamageSeverityCode2 = "c",
			DeclineAmendReasonCode = "h8s",
			ChargeAllowanceQualifier = "b6",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.DamageAreaCode = "Yv";
		subject.DamageTypeCode = "z9";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
			subject.TotalLaborCost = "r4t";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "r4t";
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yv", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageTypeCode = "z9";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
			subject.TotalLaborCost = "r4t";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "r4t";
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z9", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageAreaCode = "Yv";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
			subject.TotalLaborCost = "r4t";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "r4t";
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageAreaCode = "Yv";
		subject.DamageTypeCode = "z9";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
			subject.TotalLaborCost = "r4t";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "r4t";
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("1", "d", "r4t", true)]
	[InlineData("1", "", "", false)]
	[InlineData("", "d", "r4t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageAreaCode = "Yv";
		subject.DamageTypeCode = "z9";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		subject.TotalLaborCost = totalLaborCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("r4t", "1", "d", true)]
	[InlineData("r4t", "", "", false)]
	[InlineData("", "1", "d", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageAreaCode = "Yv";
		subject.DamageTypeCode = "z9";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "7Tg";
		//Test Parameters
		subject.TotalLaborCost = totalLaborCost;
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7Tg", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 3;
		subject.DamageAreaCode = "Yv";
		subject.DamageTypeCode = "z9";
		subject.DamageSeverityCode = "R";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
			subject.TotalLaborCost = "r4t";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "r4t";
			subject.LaborHours = "1";
			subject.LaborHours2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
