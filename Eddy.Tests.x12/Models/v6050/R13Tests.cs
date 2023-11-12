using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class R13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R13*C*K*h*Y*N*L*rl*4*i*S*r*7*E*H";

		var expected = new R13_LineItemRepair()
		{
			AssignedIdentification = "C",
			IndustryCode = "K",
			IndustryCode2 = "h",
			IndustryCode3 = "Y",
			IndustryCode4 = "N",
			IndustryCode5 = "L",
			UnitOrBasisForMeasurementCode = "rl",
			Quantity = 4,
			YesNoConditionOrResponseCode = "i",
			Description = "S",
			Description2 = "r",
			Quantity2 = 7,
			Description3 = "E",
			Description4 = "H",
		};

		var actual = Map.MapObject<R13_LineItemRepair>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.IndustryCode = "K";
		subject.IndustryCode2 = "h";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode4 = "N";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode2 = "h";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode4 = "N";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "K";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode4 = "N";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredIndustryCode3(string industryCode3, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "K";
		subject.IndustryCode2 = "h";
		subject.IndustryCode4 = "N";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.IndustryCode3 = industryCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredIndustryCode4(string industryCode4, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "K";
		subject.IndustryCode2 = "h";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.IndustryCode4 = industryCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredIndustryCode5(string industryCode5, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "K";
		subject.IndustryCode2 = "h";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode4 = "N";
		//Test Parameters
		subject.IndustryCode5 = industryCode5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "rl";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rl", 4, true)]
	[InlineData("rl", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "K";
		subject.IndustryCode2 = "h";
		subject.IndustryCode3 = "Y";
		subject.IndustryCode4 = "N";
		subject.IndustryCode5 = "L";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
