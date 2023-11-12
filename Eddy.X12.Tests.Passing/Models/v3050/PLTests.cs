using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050.Composites;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PL*5**j*j*d*4";

		var expected = new PL_ProposalCostLogic()
		{
			AssignedNumber = 5,
			CompositeUnitOfMeasure = null,
			Name = "j",
			CalculationOperationCode = "j",
			Description = "d",
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
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "j";
		subject.CalculationOperationCode = "j";
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
		subject.AssignedNumber = 5;
		subject.Name = "j";
		subject.CalculationOperationCode = "j";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 5;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.CalculationOperationCode = "j";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredCalculationOperationCode(string calculationOperationCode, bool isValidExpected)
	{
		var subject = new PL_ProposalCostLogic();
		//Required fields
		subject.AssignedNumber = 5;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "j";
		//Test Parameters
		subject.CalculationOperationCode = calculationOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
