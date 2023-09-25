using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class AINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AIN*eO*F*1*2*C*T*d*h*1*2M*4*g*5";

		var expected = new AIN_Income()
		{
			TypeOfIncomeCode = "eO",
			FrequencyCode = "F",
			MonetaryAmount = 1,
			Quantity = 2,
			YesNoConditionOrResponseCode = "C",
			ReferenceIdentification = "T",
			AmountQualifierCode = "d",
			TaxTreatmentCode = "h",
			EarningsRateOfPay = 1,
			UnitOrBasisForMeasurementCode = "2M",
			Quantity2 = 4,
			IndustryCode = "g",
			Description = "5",
		};

		var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eO", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.FrequencyCode = "F";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "eO";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "eO";
		subject.FrequencyCode = "F";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
