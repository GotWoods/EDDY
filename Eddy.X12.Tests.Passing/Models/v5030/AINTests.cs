using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class AINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AIN*K9*1*1*8*Z*i*k*C*9*zf*4*G*I";

		var expected = new AIN_Income()
		{
			TypeOfIncomeCode = "K9",
			FrequencyCode = "1",
			MonetaryAmount = 1,
			Quantity = 8,
			YesNoConditionOrResponseCode = "Z",
			ReferenceIdentification = "i",
			AmountQualifierCode = "k",
			TaxTreatmentCode = "C",
			EarningsRateOfPay = 9,
			UnitOrBasisForMeasurementCode = "zf",
			Quantity2 = 4,
			IndustryCode = "G",
			Description = "I",
		};

		var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K9", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.FrequencyCode = "1";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "K9";
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
		subject.TypeOfIncomeCode = "K9";
		subject.FrequencyCode = "1";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
