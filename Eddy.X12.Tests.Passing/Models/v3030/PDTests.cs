using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*D4*PRFWjv*Yc*7*N*4*Ef";

		var expected = new PD_ProposalData()
		{
			UnitOfTimePeriodOrInterval = "D4",
			Date = "PRFWjv",
			UnitOrBasisForMeasurementCode = "Yc",
			Quantity = 7,
			Name = "N",
			Description = "4",
			BreakdownStructureDetailCode = "Ef",
		};

		var actual = Map.MapObject<PD_ProposalData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D4", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.Date = "PRFWjv";
		subject.UnitOrBasisForMeasurementCode = "Yc";
		subject.Quantity = 7;
		subject.Name = "N";
		subject.Description = "4";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PRFWjv", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "D4";
		subject.UnitOrBasisForMeasurementCode = "Yc";
		subject.Quantity = 7;
		subject.Name = "N";
		subject.Description = "4";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yc", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "D4";
		subject.Date = "PRFWjv";
		subject.Quantity = 7;
		subject.Name = "N";
		subject.Description = "4";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "D4";
		subject.Date = "PRFWjv";
		subject.UnitOrBasisForMeasurementCode = "Yc";
		subject.Name = "N";
		subject.Description = "4";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "D4";
		subject.Date = "PRFWjv";
		subject.UnitOrBasisForMeasurementCode = "Yc";
		subject.Quantity = 7;
		subject.Description = "4";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "D4";
		subject.Date = "PRFWjv";
		subject.UnitOrBasisForMeasurementCode = "Yc";
		subject.Quantity = 7;
		subject.Name = "N";
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
