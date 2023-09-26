using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PD*c4*zLfq5N*uv*7*z*x*6A*2*V*s";

		var expected = new PD_ProposalData()
		{
			UnitOfTimePeriodOrInterval = "c4",
			Date = "zLfq5N",
			UnitOrBasisForMeasurementCode = "uv",
			Quantity = 7,
			Name = "z",
			Description = "x",
			BreakdownStructureDetailCode = "6A",
			ReferenceNumber = "2",
			Description2 = "V",
			ProposalDataDetailIdentifierCode = "s",
		};

		var actual = Map.MapObject<PD_ProposalData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c4", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.Date = "zLfq5N";
		subject.UnitOrBasisForMeasurementCode = "uv";
		subject.Quantity = 7;
		subject.Name = "z";
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zLfq5N", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "c4";
		subject.UnitOrBasisForMeasurementCode = "uv";
		subject.Quantity = 7;
		subject.Name = "z";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uv", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "c4";
		subject.Date = "zLfq5N";
		subject.Quantity = 7;
		subject.Name = "z";
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
		subject.UnitOfTimePeriodOrInterval = "c4";
		subject.Date = "zLfq5N";
		subject.UnitOrBasisForMeasurementCode = "uv";
		subject.Name = "z";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PD_ProposalData();
		//Required fields
		subject.UnitOfTimePeriodOrInterval = "c4";
		subject.Date = "zLfq5N";
		subject.UnitOrBasisForMeasurementCode = "uv";
		subject.Quantity = 7;
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
