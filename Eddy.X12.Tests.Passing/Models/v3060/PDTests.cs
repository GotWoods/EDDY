using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*nH*PGR0jG**4*M*Q*jb*y*l*E";

		var expected = new PD_PricingData()
		{
			UnitOfTimePeriodOrInterval = "nH",
			Date = "PGR0jG",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Name = "M",
			Description = "Q",
			BreakdownStructureDetailCode = "jb",
			ReferenceIdentification = "y",
			Description2 = "l",
			ProposalDataDetailIdentifierCode = "E",
		};

		var actual = Map.MapObject<PD_PricingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nH", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.Date = "PGR0jG";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.Name = "M";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PGR0jG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "nH";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		subject.Name = "M";
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
		subject.UnitOfTimePeriodOrInterval = "nH";
		subject.Date = "PGR0jG";
		subject.Quantity = 4;
		subject.Name = "M";
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
		subject.UnitOfTimePeriodOrInterval = "nH";
		subject.Date = "PGR0jG";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Name = "M";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_PricingData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "nH";
		subject.Date = "PGR0jG";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 4;
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
