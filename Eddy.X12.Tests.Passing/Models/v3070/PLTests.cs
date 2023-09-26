using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PL*8**L*3*f*9";

		var expected = new PL_ProposalCostLogic()
		{
			AssignedNumber = 8,
			CompositeUnitOfMeasure = null,
			Name = "L",
			CalculationOperationCode = "3",
			Description = "f",
			Count = 9,
		};

		var actual = Map.MapObject<PL_ProposalCostLogic>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "L";
		subject.CalculationOperationCode = "3";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 8;
		subject.Name = "L";
		subject.CalculationOperationCode = "3";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 8;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.CalculationOperationCode = "3";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredCalculationOperationCode(string calculationOperationCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 8;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "L";
		//Test Parameters
		subject.CalculationOperationCode = calculationOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
