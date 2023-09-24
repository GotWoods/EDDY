using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*Dy*p*xo*9*TD*5*kT*6*GJ*6*U3*6*Cx*9*ul*6*tD*5*PX*8*X7*6*q";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOrBasisForMeasurementCode = "Dy",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "xo",
			Quantity = 9,
			IdentificationCode2 = "TD",
			Quantity2 = 5,
			IdentificationCode3 = "kT",
			Quantity3 = 6,
			IdentificationCode4 = "GJ",
			Quantity4 = 6,
			IdentificationCode5 = "U3",
			Quantity5 = 6,
			IdentificationCode6 = "Cx",
			Quantity6 = 9,
			IdentificationCode7 = "ul",
			Quantity7 = 6,
			IdentificationCode8 = "tD",
			Quantity8 = 5,
			IdentificationCode9 = "PX",
			Quantity9 = 8,
			IdentificationCode10 = "X7",
			Quantity10 = 6,
			LocationIdentifier = "q",
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dy", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xo", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TD", 5, true)]
	[InlineData("TD", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("kT", 6, true)]
	[InlineData("kT", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("GJ", 6, true)]
	[InlineData("GJ", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U3", 6, true)]
	[InlineData("U3", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Cx", 9, true)]
	[InlineData("Cx", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ul", 6, true)]
	[InlineData("ul", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tD", 5, true)]
	[InlineData("tD", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("PX", 8, true)]
	[InlineData("PX", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "X7";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X7", 6, true)]
	[InlineData("X7", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Dy";
		subject.IdentificationCode = "xo";
		subject.Quantity = 9;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "TD";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "kT";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "GJ";
			subject.Quantity4 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "U3";
			subject.Quantity5 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "Cx";
			subject.Quantity6 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "ul";
			subject.Quantity7 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "tD";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "PX";
			subject.Quantity9 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
