using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*UY*i*FF*5*Dd*9*q0*6*Sm*9*e0*8*wu*1*qA*6*Lv*1*k0*1*Ck*5*e";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOrBasisForMeasurementCode = "UY",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "FF",
			Quantity = 5,
			IdentificationCode2 = "Dd",
			Quantity2 = 9,
			IdentificationCode3 = "q0",
			Quantity3 = 6,
			IdentificationCode4 = "Sm",
			Quantity4 = 9,
			IdentificationCode5 = "e0",
			Quantity5 = 8,
			IdentificationCode6 = "wu",
			Quantity6 = 1,
			IdentificationCode7 = "qA",
			Quantity7 = 6,
			IdentificationCode8 = "Lv",
			Quantity8 = 1,
			IdentificationCode9 = "k0",
			Quantity9 = 1,
			IdentificationCode10 = "Ck",
			Quantity10 = 5,
			LocationIdentifier = "e",
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UY", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FF", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Dd", 9, true)]
	[InlineData("Dd", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("q0", 6, true)]
	[InlineData("q0", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Sm", 9, true)]
	[InlineData("Sm", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e0", 8, true)]
	[InlineData("e0", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("wu", 1, true)]
	[InlineData("wu", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("qA", 6, true)]
	[InlineData("qA", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Lv", 1, true)]
	[InlineData("Lv", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k0", 1, true)]
	[InlineData("k0", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "Ck";
			subject.Quantity10 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ck", 5, true)]
	[InlineData("Ck", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "UY";
		subject.IdentificationCode = "FF";
		subject.Quantity = 5;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "Dd";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "q0";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "Sm";
			subject.Quantity4 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "e0";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "wu";
			subject.Quantity6 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "qA";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "Lv";
			subject.Quantity8 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "k0";
			subject.Quantity9 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
