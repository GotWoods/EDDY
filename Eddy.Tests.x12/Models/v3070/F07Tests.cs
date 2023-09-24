using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*8*7*b*U9g*B*qh*JW*h*G6F3P*Q*a*a*Fr9*AY*YuG*F*o*iH*q6*e*IcU*mi";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 8,
			Quantity = 7,
			ProductServiceID = "b",
			PartName = "U9g",
			Amount = "B",
			DamageAreaCode = "qh",
			DamageTypeCode = "JW",
			DamageSeverityCode = "h",
			LaborOperationIdentifier = "G6F3P",
			FreeFormDescription = "Q",
			LaborHours = "a",
			LaborHours2 = "a",
			TotalLaborCost = "Fr9",
			TotalMiscellaneousCosts = "AY",
			TotalRepairCost = "YuG",
			AuthorizationIdentification = "F",
			InspectionLocationTypeCode = "o",
			DamageAreaCode2 = "iH",
			DamageTypeCode2 = "q6",
			DamageSeverityCode2 = "e",
			DeclineAmendReasonCode = "IcU",
			ChargeAllowanceQualifier = "mi",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.DamageAreaCode = "qh";
		subject.DamageTypeCode = "JW";
		subject.DamageSeverityCode = "h";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
			subject.TotalLaborCost = "Fr9";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Fr9";
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qh", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageTypeCode = "JW";
		subject.DamageSeverityCode = "h";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
			subject.TotalLaborCost = "Fr9";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Fr9";
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JW", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageAreaCode = "qh";
		subject.DamageSeverityCode = "h";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
			subject.TotalLaborCost = "Fr9";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Fr9";
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageAreaCode = "qh";
		subject.DamageTypeCode = "JW";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
			subject.TotalLaborCost = "Fr9";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Fr9";
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("a", "a", "Fr9", true)]
	[InlineData("a", "", "", false)]
	[InlineData("", "a", "Fr9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageAreaCode = "qh";
		subject.DamageTypeCode = "JW";
		subject.DamageSeverityCode = "h";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		subject.TotalLaborCost = totalLaborCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Fr9", "a", "a", true)]
	[InlineData("Fr9", "", "", false)]
	[InlineData("", "a", "a", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageAreaCode = "qh";
		subject.DamageTypeCode = "JW";
		subject.DamageSeverityCode = "h";
		subject.TotalRepairCost = "YuG";
		//Test Parameters
		subject.TotalLaborCost = totalLaborCost;
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YuG", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 8;
		subject.DamageAreaCode = "qh";
		subject.DamageTypeCode = "JW";
		subject.DamageSeverityCode = "h";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
			subject.TotalLaborCost = "Fr9";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Fr9";
			subject.LaborHours = "a";
			subject.LaborHours2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
