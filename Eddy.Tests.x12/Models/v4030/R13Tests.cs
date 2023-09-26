using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class R13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R13*C*n*j*M*B*E*ZY*5*J*w*4*1";

		var expected = new R13_LineItemRepair()
		{
			AssignedIdentification = "C",
			IndustryCode = "n",
			IndustryCode2 = "j",
			IndustryCode3 = "M",
			IndustryCode4 = "B",
			IndustryCode5 = "E",
			UnitOrBasisForMeasurementCode = "ZY",
			Quantity = 5,
			YesNoConditionOrResponseCode = "J",
			Description = "w",
			Description2 = "4",
			Quantity2 = 1,
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
		subject.IndustryCode = "n";
		subject.IndustryCode2 = "j";
		subject.IndustryCode3 = "M";
		subject.IndustryCode4 = "B";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode2 = "j";
		subject.IndustryCode3 = "M";
		subject.IndustryCode4 = "B";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "n";
		subject.IndustryCode3 = "M";
		subject.IndustryCode4 = "B";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredIndustryCode3(string industryCode3, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "n";
		subject.IndustryCode2 = "j";
		subject.IndustryCode4 = "B";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.IndustryCode3 = industryCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredIndustryCode4(string industryCode4, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "n";
		subject.IndustryCode2 = "j";
		subject.IndustryCode3 = "M";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.IndustryCode4 = industryCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredIndustryCode5(string industryCode5, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "n";
		subject.IndustryCode2 = "j";
		subject.IndustryCode3 = "M";
		subject.IndustryCode4 = "B";
		//Test Parameters
		subject.IndustryCode5 = industryCode5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "ZY";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ZY", 5, true)]
	[InlineData("ZY", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new R13_LineItemRepair();
		//Required fields
		subject.AssignedIdentification = "C";
		subject.IndustryCode = "n";
		subject.IndustryCode2 = "j";
		subject.IndustryCode3 = "M";
		subject.IndustryCode4 = "B";
		subject.IndustryCode5 = "E";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
