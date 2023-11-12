using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ**A*pn*1*WS*1*x1*9*NP*1*C1*8*e7*3*6T*4*WJ*6*rz*9*xW*6*w";

		var expected = new SDQ_DestinationQuantity()
		{
			CompositeUnitOfMeasure = null,
			IdentificationCodeQualifier = "A",
			IdentificationCode = "pn",
			Quantity = 1,
			IdentificationCode2 = "WS",
			Quantity2 = 1,
			IdentificationCode3 = "x1",
			Quantity3 = 9,
			IdentificationCode4 = "NP",
			Quantity4 = 1,
			IdentificationCode5 = "C1",
			Quantity5 = 8,
			IdentificationCode6 = "e7",
			Quantity6 = 3,
			IdentificationCode7 = "6T",
			Quantity7 = 4,
			IdentificationCode8 = "WJ",
			Quantity8 = 6,
			IdentificationCode9 = "rz",
			Quantity9 = 9,
			IdentificationCode10 = "xW",
			Quantity10 = 6,
			LocationIdentifier = "w",
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pn", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("WS", 1, true)]
	[InlineData("WS", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("x1", 9, true)]
	[InlineData("x1", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("NP", 1, true)]
	[InlineData("NP", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C1", 8, true)]
	[InlineData("C1", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e7", 3, true)]
	[InlineData("e7", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6T", 4, true)]
	[InlineData("6T", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("WJ", 6, true)]
	[InlineData("WJ", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rz", 9, true)]
	[InlineData("rz", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode10) || !string.IsNullOrEmpty(subject.IdentificationCode10) || subject.Quantity10 > 0)
		{
			subject.IdentificationCode10 = "xW";
			subject.Quantity10 = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("xW", 6, true)]
	[InlineData("xW", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.IdentificationCode = "pn";
		subject.Quantity = 1;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode2) || !string.IsNullOrEmpty(subject.IdentificationCode2) || subject.Quantity2 > 0)
		{
			subject.IdentificationCode2 = "WS";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode3) || !string.IsNullOrEmpty(subject.IdentificationCode3) || subject.Quantity3 > 0)
		{
			subject.IdentificationCode3 = "x1";
			subject.Quantity3 = 9;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode4) || !string.IsNullOrEmpty(subject.IdentificationCode4) || subject.Quantity4 > 0)
		{
			subject.IdentificationCode4 = "NP";
			subject.Quantity4 = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode5) || !string.IsNullOrEmpty(subject.IdentificationCode5) || subject.Quantity5 > 0)
		{
			subject.IdentificationCode5 = "C1";
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode6) || !string.IsNullOrEmpty(subject.IdentificationCode6) || subject.Quantity6 > 0)
		{
			subject.IdentificationCode6 = "e7";
			subject.Quantity6 = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode7) || !string.IsNullOrEmpty(subject.IdentificationCode7) || subject.Quantity7 > 0)
		{
			subject.IdentificationCode7 = "6T";
			subject.Quantity7 = 4;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode8) || !string.IsNullOrEmpty(subject.IdentificationCode8) || subject.Quantity8 > 0)
		{
			subject.IdentificationCode8 = "WJ";
			subject.Quantity8 = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode9) || !string.IsNullOrEmpty(subject.IdentificationCode9) || subject.Quantity9 > 0)
		{
			subject.IdentificationCode9 = "rz";
			subject.Quantity9 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
