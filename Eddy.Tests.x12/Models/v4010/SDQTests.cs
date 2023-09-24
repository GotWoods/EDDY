using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*CX*S*gq*4*4g*9*li*6*SW*5*bM*5*iy*6*jK*2*iY*5*8t*2*yb*8*3";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOrBasisForMeasurementCode = "CX",
			IdentificationCodeQualifier = "S",
			IdentificationCode = "gq",
			Quantity = 4,
			IdentificationCode2 = "4g",
			Quantity2 = 9,
			IdentificationCode3 = "li",
			Quantity3 = 6,
			IdentificationCode4 = "SW",
			Quantity4 = 5,
			IdentificationCode5 = "bM",
			Quantity5 = 5,
			IdentificationCode6 = "iy",
			Quantity6 = 6,
			IdentificationCode7 = "jK",
			Quantity7 = 2,
			IdentificationCode8 = "iY",
			Quantity8 = 5,
			IdentificationCode9 = "8t",
			Quantity9 = 2,
			IdentificationCode10 = "yb",
			Quantity10 = 8,
			LocationIdentifier = "3",
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CX", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gq", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4g", 9, true)]
	[InlineData("4g", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("li", 6, true)]
	[InlineData("li", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("SW", 5, true)]
	[InlineData("SW", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("bM", 5, true)]
	[InlineData("bM", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iy", 6, true)]
	[InlineData("iy", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("jK", 2, true)]
	[InlineData("jK", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iY", 5, true)]
	[InlineData("iY", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8t", 2, true)]
	[InlineData("8t", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "yb";
			subject.Quantity10 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("yb", 8, true)]
	[InlineData("yb", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "CX";
		subject.IdentificationCode = "gq";
		subject.Quantity = 4;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "4g";
			subject.Quantity2 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "li";
			subject.Quantity3 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "SW";
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "bM";
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "iy";
			subject.Quantity6 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "jK";
			subject.Quantity7 = 2;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "iY";
			subject.Quantity8 = 5;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "8t";
			subject.Quantity9 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
