using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PEX*yp*QL*7*VU*P*Hf*i*";

		var expected = new PEX_PropertyOrHousingExpense()
		{
			GeneralExpenseQualifier = "yp",
			RateValueQualifier = "QL",
			MonetaryAmount = 7,
			TaxTypeCode = "VU",
			YesNoConditionOrResponseCode = "P",
			EntityIdentifierCode = "Hf",
			TaxExemptCode = "i",
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<PEX_PropertyOrHousingExpense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yp", true)]
	public void Validation_RequiredGeneralExpenseQualifier(string generalExpenseQualifier, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		//Test Parameters
		subject.GeneralExpenseQualifier = generalExpenseQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.MonetaryAmount > 0)
		{
			subject.RateValueQualifier = "QL";
			subject.MonetaryAmount = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("QL", 7, true)]
	[InlineData("QL", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PEX_PropertyOrHousingExpense();
		//Required fields
		subject.GeneralExpenseQualifier = "yp";
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
