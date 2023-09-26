using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class AINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AIN*Sw*iN*5*5*z";

		var expected = new AIN_Income()
		{
			TypeOfIncomeCode = "Sw",
			UnitOrBasisForMeasurementCode = "iN",
			MonetaryAmount = 5,
			Quantity = 5,
			YesNoConditionOrResponseCode = "z",
		};

		var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sw", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "iN";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iN", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "Sw";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "Sw";
		subject.UnitOrBasisForMeasurementCode = "iN";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
