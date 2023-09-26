using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PL*5*Rz*Y*G*r";

		var expected = new PL_ProposalCostLogic()
		{
			AssignedNumber = 5,
			UnitOrBasisForMeasurementCode = "Rz",
			Name = "Y",
			CalculationOperationCode = "G",
			Description = "r",
		};

		var actual = Map.MapObject<PL_ProposalCostLogic>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Rz";
		subject.Name = "Y";
		subject.CalculationOperationCode = "G";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rz", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 5;
		subject.Name = "Y";
		subject.CalculationOperationCode = "G";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 5;
		subject.UnitOrBasisForMeasurementCode = "Rz";
		subject.CalculationOperationCode = "G";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredCalculationOperationCode(string calculationOperationCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 5;
		subject.UnitOrBasisForMeasurementCode = "Rz";
		subject.Name = "Y";
		//Test Parameters
		subject.CalculationOperationCode = calculationOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
