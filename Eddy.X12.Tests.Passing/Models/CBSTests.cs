using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CBSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CBS*5*4*11";

		var expected = new CBS_CostBreakdownStructure()
		{
			AssignedIdentification = "5",
			Quantity = 4,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = "11"},
		};

		var actual = Map.MapObject<CBS_CostBreakdownStructure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		// try
		// {
			Assert.Equivalent(expected, actual);
		// }
		// catch
		// {
		// 	Assert.Fail(actual.ValidationResult.ToString());
		// }
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new CBS_CostBreakdownStructure();
		subject.Quantity = 4;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CBS_CostBreakdownStructure();
		subject.AssignedIdentification = "5";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AB", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new CBS_CostBreakdownStructure();
		subject.AssignedIdentification = "5";
		subject.Quantity = 4;
		if (compositeUnitOfMeasure != "")
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
