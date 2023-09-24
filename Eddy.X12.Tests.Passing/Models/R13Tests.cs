using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R13*3*f*s*4*7*Y*d5*9*C*9*I*2*1*E";

		var expected = new R13_LineItemRepair()
		{
			AssignedIdentification = "3",
			IndustryCode = "f",
			IndustryCode2 = "s",
			IndustryCode3 = "4",
			IndustryCode4 = "7",
			IndustryCode5 = "Y",
			UnitOrBasisForMeasurementCode = "d5",
			Quantity = 9,
			YesNoConditionOrResponseCode = "C",
			Description = "9",
			Description2 = "I",
			Quantity2 = 2,
			Description3 = "1",
			Description4 = "E",
		};

		var actual = Map.MapObject<R13_LineItemRepair>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.IndustryCode = "f";
		subject.IndustryCode2 = "s";
		subject.IndustryCode3 = "4";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = "Y";
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode2 = "s";
		subject.IndustryCode3 = "4";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = "Y";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode = "f";
		subject.IndustryCode3 = "4";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = "Y";
		subject.IndustryCode2 = industryCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIndustryCode3(string industryCode3, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode = "f";
		subject.IndustryCode2 = "s";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = "Y";
		subject.IndustryCode3 = industryCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredIndustryCode4(string industryCode4, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode = "f";
		subject.IndustryCode2 = "s";
		subject.IndustryCode3 = "4";
		subject.IndustryCode5 = "Y";
		subject.IndustryCode4 = industryCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredIndustryCode5(string industryCode5, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode = "f";
		subject.IndustryCode2 = "s";
		subject.IndustryCode3 = "4";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = industryCode5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("d5", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("d5", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		subject.AssignedIdentification = "3";
		subject.IndustryCode = "f";
		subject.IndustryCode2 = "s";
		subject.IndustryCode3 = "4";
		subject.IndustryCode4 = "7";
		subject.IndustryCode5 = "Y";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
