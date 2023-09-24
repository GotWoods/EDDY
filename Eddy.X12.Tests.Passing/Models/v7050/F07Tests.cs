using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*4*5*C*wTX*7*cs*pQ*L*zaHDX*2*i*i*Nkj*AD*vpC*e*k*n8*fK*N*hSl*Vm";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 4,
			Quantity = 5,
			ProductServiceID = "C",
			PartName = "wTX",
			Amount = "7",
			DamageAreaCode = "cs",
			DamageTypeCode = "pQ",
			DamageSeverityCode = "L",
			LaborOperationIdentifier = "zaHDX",
			FreeFormDescription = "2",
			LaborHours = "i",
			LaborHours2 = "i",
			TotalLaborCost = "Nkj",
			TotalMiscellaneousCosts = "AD",
			TotalRepairCost = "vpC",
			AuthorizationIdentification = "e",
			InspectionLocationTypeCode = "k",
			DamageAreaCode2 = "n8",
			DamageTypeCode2 = "fK",
			DamageSeverityCode2 = "N",
			DeclineAmendReasonCode = "hSl",
			ChargeAllowanceQualifier = "Vm",
		};

		var actual = Map.MapObject<F07_AutoClaimDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.DamageAreaCode = "cs";
		subject.DamageTypeCode = "pQ";
		subject.DamageSeverityCode = "L";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
			subject.TotalLaborCost = "Nkj";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Nkj";
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cs", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageTypeCode = "pQ";
		subject.DamageSeverityCode = "L";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
			subject.TotalLaborCost = "Nkj";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Nkj";
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pQ", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "cs";
		subject.DamageSeverityCode = "L";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
			subject.TotalLaborCost = "Nkj";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Nkj";
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "cs";
		subject.DamageTypeCode = "pQ";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
			subject.TotalLaborCost = "Nkj";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Nkj";
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("i", "i", "Nkj", true)]
	[InlineData("i", "", "", false)]
	[InlineData("", "i", "Nkj", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_LaborHours(string laborHours, string laborHours2, string totalLaborCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "cs";
		subject.DamageTypeCode = "pQ";
		subject.DamageSeverityCode = "L";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		subject.TotalLaborCost = totalLaborCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Nkj", "i", "i", true)]
	[InlineData("Nkj", "", "", false)]
	[InlineData("", "i", "i", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TotalLaborCost(string totalLaborCost, string laborHours, string laborHours2, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "cs";
		subject.DamageTypeCode = "pQ";
		subject.DamageSeverityCode = "L";
		subject.TotalRepairCost = "vpC";
		//Test Parameters
		subject.TotalLaborCost = totalLaborCost;
		subject.LaborHours = laborHours;
		subject.LaborHours2 = laborHours2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vpC", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "cs";
		subject.DamageTypeCode = "pQ";
		subject.DamageSeverityCode = "L";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2) || !string.IsNullOrEmpty(subject.TotalLaborCost))
		{
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
			subject.TotalLaborCost = "Nkj";
		}
		if(!string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.TotalLaborCost) || !string.IsNullOrEmpty(subject.LaborHours) || !string.IsNullOrEmpty(subject.LaborHours2))
		{
			subject.TotalLaborCost = "Nkj";
			subject.LaborHours = "i";
			subject.LaborHours2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
