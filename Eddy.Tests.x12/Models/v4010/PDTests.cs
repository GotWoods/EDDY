using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*N6*UXTfqAIe**4*U*5*ra*g*k*1";

		var expected = new PD_PricingData()
		{
			UnitOfTimePeriodOrInterval = "N6",
			Date = "UXTfqAIe",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Name = "U",
			Description = "5",
			BreakdownStructureDetailCode = "ra",
			ReferenceIdentification = "g",
			Description2 = "k",
			ProposalDataDetailIdentifierCode = "1",
		};

		var actual = Map.MapObject<PD_PricingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N6", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.Date = "UXTfqAIe";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.Name = "U";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UXTfqAIe", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "N6";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.Name = "U";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "N6";
		subject.Date = "UXTfqAIe";
		subject.Quantity = 4;
		subject.Name = "U";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "N6";
		subject.Date = "UXTfqAIe";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "U";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "N6";
		subject.Date = "UXTfqAIe";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
