using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*nJ*5Rq6Dy81**2*6*r*7N*V*i*K";

		var expected = new PD_PricingData()
		{
			UnitOfTimePeriodOrIntervalCode = "nJ",
			Date = "5Rq6Dy81",
			CompositeUnitOfMeasure = null,
			Quantity = 2,
			Name = "6",
			Description = "r",
			BreakdownStructureDetailCode = "7N",
			ReferenceIdentification = "V",
			Description2 = "i",
			ProposalDataDetailIdentifierCode = "K",
		};

		var actual = Map.MapObject<PD_PricingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nJ", true)]
	public void Validation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.Date = "5Rq6Dy81";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 2;
		subject.Name = "6";
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5Rq6Dy81", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrIntervalCode = "nJ";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 2;
		subject.Name = "6";
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
		subject.UnitOfTimePeriodOrIntervalCode = "nJ";
		subject.Date = "5Rq6Dy81";
		subject.Quantity = 2;
		subject.Name = "6";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrIntervalCode = "nJ";
		subject.Date = "5Rq6Dy81";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "6";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrIntervalCode = "nJ";
		subject.Date = "5Rq6Dy81";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 2;
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
