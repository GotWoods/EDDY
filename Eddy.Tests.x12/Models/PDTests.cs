using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*Xl*dM5Lwzly**5*7*c*hd*4*m*x";

		var expected = new PD_PricingData()
		{
			UnitOfTimePeriodOrIntervalCode = "Xl",
			Date = "dM5Lwzly",
			CompositeUnitOfMeasure = null,
			Quantity = 5,
			Name = "7",
			Description = "c",
			BreakdownStructureDetailCode = "hd",
			ReferenceIdentification = "4",
			Description2 = "m",
			ProposalDataDetailIdentifierCode = "x",
		};

		var actual = Map.MapObject<PD_PricingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xl", true)]
	public void Validation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		subject.Date = "dM5Lwzly";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 5;
		subject.Name = "7";
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dM5Lwzly", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		subject.UnitOfTimePeriodOrIntervalCode = "Xl";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 5;
		subject.Name = "7";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		subject.UnitOfTimePeriodOrIntervalCode = "Xl";
		subject.Date = "dM5Lwzly";
		subject.Quantity = 5;
		subject.Name = "7";

		if (compositeUnitOfMeasure != "")
		{
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		subject.UnitOfTimePeriodOrIntervalCode = "Xl";
		subject.Date = "dM5Lwzly";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "7";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		subject.UnitOfTimePeriodOrIntervalCode = "Xl";
		subject.Date = "dM5Lwzly";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 5;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
