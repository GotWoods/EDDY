using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*Ow*F*R4*3*PP*7*6o*1*Fe*7*BF*9*aI*4*b3*6*AB*6*xH*5*ED*3*N";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOrBasisForMeasurementCode = "Ow",
			IdentificationCodeQualifier = "F",
			IdentificationCode = "R4",
			Quantity = 3,
			IdentificationCode2 = "PP",
			Quantity2 = 7,
			IdentificationCode3 = "6o",
			Quantity3 = 1,
			IdentificationCode4 = "Fe",
			Quantity4 = 7,
			IdentificationCode5 = "BF",
			Quantity5 = 9,
			IdentificationCode6 = "aI",
			Quantity6 = 4,
			IdentificationCode7 = "b3",
			Quantity7 = 6,
			IdentificationCode8 = "AB",
			Quantity8 = 6,
			IdentificationCode9 = "xH",
			Quantity9 = 5,
			IdentificationCode10 = "ED",
			Quantity10 = 3,
			LocationIdentifier = "N",
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ow", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R4", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("PP", 7, true)]
	[InlineData("PP", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6o", 1, true)]
	[InlineData("6o", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Fe", 7, true)]
	[InlineData("Fe", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("BF", 9, true)]
	[InlineData("BF", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("aI", 4, true)]
	[InlineData("aI", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b3", 6, true)]
	[InlineData("b3", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("AB", 6, true)]
	[InlineData("AB", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("xH", 5, true)]
	[InlineData("xH", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ED", 3, true)]
	[InlineData("ED", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ow";
		subject.IdentificationCode = "R4";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
