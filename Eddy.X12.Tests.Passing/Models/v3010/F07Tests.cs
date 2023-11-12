using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F07*4*9*T*Tv6*n*5Y*Ce*R*SCnSu*r*i*9*Bgz*o1*A5i*D*X*YY*cb*h*IP2*mi";

		var expected = new F07_AutoClaimDetail()
		{
			AssignedNumber = 4,
			Quantity = 9,
			ProductServiceID = "T",
			PartName = "Tv6",
			Amount = "n",
			DamageAreaCode = "5Y",
			DamageTypeCode = "Ce",
			DamageSeverityCode = "R",
			LaborOperationIdentifier = "SCnSu",
			FreeFormDescription = "r",
			LaborHours = "i",
			LaborHours2 = "9",
			TotalLaborCost = "Bgz",
			TotalMiscellaneousCosts = "o1",
			TotalRepairCost = "A5i",
			AuthorizationIdentification = "D",
			InspectionLocationTypeCode = "X",
			DamageAreaCode2 = "YY",
			DamageTypeCode2 = "cb",
			DamageSeverityCode2 = "h",
			DeclineAmendReasonCode = "IP2",
			ChargeAllowanceQualifier = "mi",
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
		subject.DamageAreaCode = "5Y";
		subject.DamageTypeCode = "Ce";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "A5i";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5Y", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageTypeCode = "Ce";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "A5i";
		//Test Parameters
		subject.DamageAreaCode = damageAreaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ce", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "5Y";
		subject.DamageSeverityCode = "R";
		subject.TotalRepairCost = "A5i";
		//Test Parameters
		subject.DamageTypeCode = damageTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "5Y";
		subject.DamageTypeCode = "Ce";
		subject.TotalRepairCost = "A5i";
		//Test Parameters
		subject.DamageSeverityCode = damageSeverityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A5i", true)]
	public void Validation_RequiredTotalRepairCost(string totalRepairCost, bool isValidExpected)
	{
		var subject = new F07_AutoClaimDetail();
		//Required fields
		subject.AssignedNumber = 4;
		subject.DamageAreaCode = "5Y";
		subject.DamageTypeCode = "Ce";
		subject.DamageSeverityCode = "R";
		//Test Parameters
		subject.TotalRepairCost = totalRepairCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
