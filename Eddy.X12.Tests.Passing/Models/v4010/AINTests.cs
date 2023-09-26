using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AIN*IQ*q*9*7*R*z*H*U*5*qo*2*2";

		var expected = new AIN_Income()
		{
			TypeOfIncomeCode = "IQ",
			FrequencyCode = "q",
			MonetaryAmount = 9,
			Quantity = 7,
			YesNoConditionOrResponseCode = "R",
			ReferenceIdentification = "z",
			AmountQualifierCode = "H",
			TaxTreatmentCode = "U",
			EarningsRateOfPay = 5,
			UnitOrBasisForMeasurementCode = "qo",
			Quantity2 = 2,
			IndustryCode = "2",
		};

		var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IQ", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.FrequencyCode = "q";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		//If one filled, all required
		if(subject.EarningsRateOfPay > 0 || subject.EarningsRateOfPay > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.EarningsRateOfPay = 5;
			subject.UnitOrBasisForMeasurementCode = "qo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "IQ";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		//If one filled, all required
		if(subject.EarningsRateOfPay > 0 || subject.EarningsRateOfPay > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.EarningsRateOfPay = 5;
			subject.UnitOrBasisForMeasurementCode = "qo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "IQ";
		subject.FrequencyCode = "q";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.EarningsRateOfPay > 0 || subject.EarningsRateOfPay > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.EarningsRateOfPay = 5;
			subject.UnitOrBasisForMeasurementCode = "qo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "qo", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "qo", false)]
	public void Validation_AllAreRequiredEarningsRateOfPay(decimal earningsRateOfPay, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "IQ";
		subject.FrequencyCode = "q";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (earningsRateOfPay > 0) 
			subject.EarningsRateOfPay = earningsRateOfPay;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
