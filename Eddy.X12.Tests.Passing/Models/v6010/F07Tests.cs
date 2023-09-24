using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*7*5*A*Vee*7*BT*Kj*g*KwH5J*m*n*t*ojk*DH*gfk*k*C*Ig*gu*u*IFo*rp";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 7,
			Quantity = 5,
			ProductServiceID = "A",
			PartName = "Vee",
			Amount = "7",
			DamageAreaCode = "BT",
			DamageTypeCode = "Kj",
			DamageSeverityCode = "g",
			LaborOperationIdentifier = "KwH5J",
			FreeFormDescription = "m",
			LaborHours = "n",
			LaborHours2 = "t",
			TotalLaborCost = "ojk",
			TotalMiscellaneousCosts = "DH",
			TotalRepairCost = "gfk",
			AuthorizationIdentification = "k",
			InspectionLocationTypeCode = "C",
			DamageAreaCode2 = "Ig",
			DamageTypeCode2 = "gu",
			DamageSeverityCode2 = "u",
			DeclineAmendReasonCode = "IFo",
			ChargeAllowanceQualifier = "rp",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.DamageAreaCode = "BT";
		subject.DamageTypeCode = "Kj";
		subject.DamageSeverityCode = "g";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
			subject.TotalLaborCost = "ojk";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "ojk";
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BT", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageTypeCode = "Kj";
		subject.DamageSeverityCode = "g";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
			subject.TotalLaborCost = "ojk";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "ojk";
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kj", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageAreaCode = "BT";
		subject.DamageSeverityCode = "g";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
			subject.TotalLaborCost = "ojk";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "ojk";
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageAreaCode = "BT";
		subject.DamageTypeCode = "Kj";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
			subject.TotalLaborCost = "ojk";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "ojk";
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("n", "t", "ojk", true)]
	[InlineData("n", "", "", false)]
	[InlineData("", "t", "ojk", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageAreaCode = "BT";
		subject.DamageTypeCode = "Kj";
		subject.DamageSeverityCode = "g";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		subject.TotalLaborCost = totalLaborCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("ojk", "n", "t", true)]
	[InlineData("ojk", "", "", false)]
	[InlineData("", "n", "t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageAreaCode = "BT";
		subject.DamageTypeCode = "Kj";
		subject.DamageSeverityCode = "g";
		subject.TotalRepairCost = "gfk";
		//Test Parameters
		subject.TotalLaborCost = totalLaborCost;
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gfk", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 7;
		subject.DamageAreaCode = "BT";
		subject.DamageTypeCode = "Kj";
		subject.DamageSeverityCode = "g";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
			subject.TotalLaborCost = "ojk";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "ojk";
			subject.LaborHours = "n";
			subject.LaborHours2 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
