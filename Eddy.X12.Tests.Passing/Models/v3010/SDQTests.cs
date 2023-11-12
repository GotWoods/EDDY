using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SDQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SDQ*Qi*h*Ue*2*5F*1*ln*8*lc*4*h0*8*5F*7*x7*5*Wl*4*cI*3*l6*7";

		var expected = new SDQ_DestinationQuantity()
		{
			UnitOfMeasurementCode = "Qi",
			IdentificationCodeQualifier = "h",
			IdentificationCode = "Ue",
			Quantity = 2,
			IdentificationCode2 = "5F",
			Quantity2 = 1,
			IdentificationCode3 = "ln",
			Quantity3 = 8,
			IdentificationCode4 = "lc",
			Quantity4 = 4,
			IdentificationCode5 = "h0",
			Quantity5 = 8,
			IdentificationCode6 = "5F",
			Quantity6 = 7,
			IdentificationCode7 = "x7",
			Quantity7 = 5,
			IdentificationCode8 = "Wl",
			Quantity8 = 4,
			IdentificationCode9 = "cI",
			Quantity9 = 3,
			IdentificationCode10 = "l6",
			Quantity10 = 7,
		};

		var actual = Map.MapObject<SDQ_DestinationQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qi", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.IdentificationCode = "Ue";
		subject.Quantity = 2;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ue", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "Qi";
		subject.Quantity = 2;
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SDQ_DestinationQuantity();
		//Required fields
		subject.UnitOfMeasurementCode = "Qi";
		subject.IdentificationCode = "Ue";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
