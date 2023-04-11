using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class NCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCA*J*c*x*7*";

		var expected = new NCA_NonconformanceAction()
		{
			AssignedIdentification = "J",
			NonconformanceResultantResponseCode = "c",
			Description = "x",
			Quantity = 7,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<NCA_NonconformanceAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("c","x", true)]
	[InlineData("", "x", true)]
	[InlineData("c", "", true)]
	public void Validation_AtLeastOneNonconformanceResultantResponseCode(string nonconformanceResultantResponseCode, string description, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		subject.NonconformanceResultantResponseCode = nonconformanceResultantResponseCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new NCA_NonconformanceAction();
		if (quantity > 0)
		subject.Quantity = quantity;

		if (compositeUnitOfMeasure != "")
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
