using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*9*1*l*8C5*V*3K*py*y*FIKtu*8*7*o*RGO*pJ*RYm*z*7*eT*u0*8*2tD*rr";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 9,
			Quantity = 1,
			ProductServiceID = "l",
			PartName = "8C5",
			Amount = "V",
			DamageAreaCode = "3K",
			DamageTypeCode = "py",
			DamageSeverityCode = "y",
			LaborOperationIdentifier = "FIKtu",
			FreeFormDescription = "8",
			LaborHours = "7",
			LaborHours2 = "o",
			TotalLaborCost = "RGO",
			TotalMiscellaneousCosts = "pJ",
			TotalRepairCost = "RYm",
			AuthorizationIdentification = "z",
			InspectionLocationTypeCode = "7",
			DamageAreaCode2 = "eT",
			DamageTypeCode2 = "u0",
			DamageSeverityCode2 = "8",
			DeclineAmendReasonCode = "2tD",
			ChargeAllowanceQualifier = "rr",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.DamageAreaCode = "3K";
		subject.DamageTypeCode = "py";
		subject.DamageSeverityCode = "y";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
			subject.TotalLaborCost = "RGO";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "RGO";
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3K", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageTypeCode = "py";
		subject.DamageSeverityCode = "y";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
			subject.TotalLaborCost = "RGO";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "RGO";
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("py", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageAreaCode = "3K";
		subject.DamageSeverityCode = "y";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
			subject.TotalLaborCost = "RGO";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "RGO";
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageAreaCode = "3K";
		subject.DamageTypeCode = "py";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
			subject.TotalLaborCost = "RGO";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "RGO";
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("7", "o", "RGO", true)]
	[InlineData("7", "", "", false)]
	[InlineData("", "o", "RGO", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageAreaCode = "3K";
		subject.DamageTypeCode = "py";
		subject.DamageSeverityCode = "y";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		subject.TotalLaborCost = totalLaborCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("RGO", "7", "o", true)]
	[InlineData("RGO", "", "", false)]
	[InlineData("", "7", "o", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageAreaCode = "3K";
		subject.DamageTypeCode = "py";
		subject.DamageSeverityCode = "y";
		subject.TotalRepairCost = "RYm";
		//Test Parameters
		subject.TotalLaborCost = totalLaborCost;
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RYm", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 9;
		subject.DamageAreaCode = "3K";
		subject.DamageTypeCode = "py";
		subject.DamageSeverityCode = "y";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
			subject.TotalLaborCost = "RGO";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "RGO";
			subject.LaborHours = "7";
			subject.LaborHours2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
