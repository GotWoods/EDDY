using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*fc*3*ru*3*Hv*4*UT*5*og*1*YE*8*lq*5*JP*8*Gk*6*6Y*7*VI*5";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOfMeasurementCode = "fc",
			IdentificationCodeQualifier = "3",
			IdentificationCode = "ru",
			Quantity = 3,
			IdentificationCode2 = "Hv",
			Quantity2 = 4,
			IdentificationCode3 = "UT",
			Quantity3 = 5,
			IdentificationCode4 = "og",
			Quantity4 = 1,
			IdentificationCode5 = "YE",
			Quantity5 = 8,
			IdentificationCode6 = "lq",
			Quantity6 = 5,
			IdentificationCode7 = "JP",
			Quantity7 = 8,
			IdentificationCode8 = "Gk",
			Quantity8 = 6,
			IdentificationCode9 = "6Y",
			Quantity9 = 7,
			IdentificationCode10 = "VI",
			Quantity10 = 5,
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fc", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ru", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
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
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Hv", 4, true)]
	[InlineData("Hv", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBIdentificationCode2(string identificationCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode2 = identificationCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("UT", 5, true)]
	[InlineData("UT", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode3(string identificationCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode3 = identificationCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("og", 1, true)]
	[InlineData("og", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBIdentificationCode4(string identificationCode4, decimal quantity4, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode4 = identificationCode4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("YE", 8, true)]
	[InlineData("YE", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBIdentificationCode5(string identificationCode5, decimal quantity5, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode5 = identificationCode5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lq", 5, true)]
	[InlineData("lq", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode6(string identificationCode6, decimal quantity6, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode6 = identificationCode6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("JP", 8, true)]
	[InlineData("JP", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBIdentificationCode7(string identificationCode7, decimal quantity7, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode7 = identificationCode7;
		if (quantity7 > 0) 
			subject.Quantity7 = quantity7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Gk", 6, true)]
	[InlineData("Gk", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBIdentificationCode8(string identificationCode8, decimal quantity8, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode8 = identificationCode8;
		if (quantity8 > 0) 
			subject.Quantity8 = quantity8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6Y", 7, true)]
	[InlineData("6Y", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBIdentificationCode9(string identificationCode9, decimal quantity9, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode9 = identificationCode9;
		if (quantity9 > 0) 
			subject.Quantity9 = quantity9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("VI", 5, true)]
	[InlineData("VI", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBIdentificationCode10(string identificationCode10, decimal quantity10, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "fc";
		subject.IdentificationCode = "ru";
		subject.Quantity = 3;
		//Test Parameters
		subject.IdentificationCode10 = identificationCode10;
		if (quantity10 > 0) 
			subject.Quantity10 = quantity10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
