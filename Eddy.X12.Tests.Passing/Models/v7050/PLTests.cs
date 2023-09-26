using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class PLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PL*1**i*d*O*4";

		var expected = new PL_ProposalCostLogic()
		{
			AssignedNumber = 1,
			CompositeUnitOfMeasure = null,
			Name = "i",
			CalculationOperationCode = "d",
			Description = "O",
			Count = 4,
		};

		var actual = Map.MapObject<PL_ProposalCostLogic>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "i";
		subject.CalculationOperationCode = "d";
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
		subject.AssignedNumber = 1;
		subject.Name = "i";
		subject.CalculationOperationCode = "d";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 1;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.CalculationOperationCode = "d";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredCalculationOperationCode(string calculationOperationCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 1;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "i";
		//Test Parameters
		subject.CalculationOperationCode = calculationOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
