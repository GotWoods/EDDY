using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*vl*D*jW*6*ix*2*Wj*8*gf*5*vH*5*Zk*6*n1*2*7k*8*7E*3*i4*7";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOrBasisForMeasurementCode = "vl",
			IdentificationCodeQualifier = "D",
			IdentificationCode = "jW",
			Quantity = 6,
			IdentificationCode2 = "ix",
			Quantity2 = 2,
			IdentificationCode3 = "Wj",
			Quantity3 = 8,
			IdentificationCode4 = "gf",
			Quantity4 = 5,
			IdentificationCode5 = "vH",
			Quantity5 = 5,
			IdentificationCode6 = "Zk",
			Quantity6 = 6,
			IdentificationCode7 = "n1",
			Quantity7 = 2,
			IdentificationCode8 = "7k",
			Quantity8 = 8,
			IdentificationCode9 = "7E",
			Quantity9 = 3,
			IdentificationCode10 = "i4",
			Quantity10 = 7,
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vl", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jW", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ix", 2, true)]
	[InlineData("ix", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Wj", 8, true)]
	[InlineData("Wj", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gf", 5, true)]
	[InlineData("gf", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("vH", 5, true)]
	[InlineData("vH", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Zk", 6, true)]
	[InlineData("Zk", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n1", 2, true)]
	[InlineData("n1", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7k", 8, true)]
	[InlineData("7k", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7E", 3, true)]
	[InlineData("7E", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("i4", 7, true)]
	[InlineData("i4", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "vl";
		subject.IdentificationCode = "jW";
		subject.Quantity = 6;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
