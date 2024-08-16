using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class C128Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:g:8:a";

		var expected = new C128_RateDetails()
		{
			RateTypeCodeQualifier = "8",
			UnitPriceBasisRate = "g",
			UnitPriceBasisQuantity = "8",
			MeasurementUnitCode = "a",
		};

		var actual = Map.MapComposite<C128_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredRateTypeCodeQualifier(string rateTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.UnitPriceBasisRate = "g";
		//Test Parameters
		subject.RateTypeCodeQualifier = rateTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredUnitPriceBasisRate(string unitPriceBasisRate, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RateTypeCodeQualifier = "8";
		//Test Parameters
		subject.UnitPriceBasisRate = unitPriceBasisRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
