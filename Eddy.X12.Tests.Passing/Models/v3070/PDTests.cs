using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*MS*FRwUdg**1*K*1*57*c*T*2";

		var expected = new PD_PricingData()
		{
			UnitOfTimePeriodOrInterval = "MS",
			Date = "FRwUdg",
			CompositeUnitOfMeasure = null,
			Quantity = 1,
			Name = "K",
			Description = "1",
			BreakdownStructureDetailCode = "57",
			ReferenceIdentification = "c",
			Description2 = "T",
			ProposalDataDetailIdentifierCode = "2",
		};

		var actual = Map.MapObject<PD_PricingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MS", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.Date = "FRwUdg";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 1;
		subject.Name = "K";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FRwUdg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "MS";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 1;
		subject.Name = "K";
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
		subject.UnitOfTimePeriodOrInterval = "MS";
		subject.Date = "FRwUdg";
		subject.Quantity = 1;
		subject.Name = "K";
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "MS";
		subject.Date = "FRwUdg";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "K";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "MS";
		subject.Date = "FRwUdg";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 1;
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
