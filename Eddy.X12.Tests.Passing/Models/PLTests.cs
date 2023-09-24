using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class PLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PL*5**z*l*K*4";

		var expected = new PL_ProposalCostLogic()
		{
			AssignedNumber = 5,
			CompositeUnitOfMeasure = null,
			Name = "z",
			CalculationOperationCode = "l",
			Description = "K",
			Count = 4,
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
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "z";
		subject.CalculationOperationCode = "l";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		subject.AssignedNumber = 5;
		subject.Name = "z";
		subject.CalculationOperationCode = "l";

		if (compositeUnitOfMeasure != "")
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		subject.AssignedNumber = 5;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.CalculationOperationCode = "l";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredCalculationOperationCode(string calculationOperationCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		subject.AssignedNumber = 5;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "z";
		subject.CalculationOperationCode = calculationOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
