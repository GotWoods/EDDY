using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C128Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:K:Z:l";

		var expected = new C128_RateDetails()
		{
			RateTypeCodeQualifier = "C",
			UnitPriceBasisRate = "K",
			UnitPriceBasisQuantity = "Z",
			MeasurementUnitCode = "l",
		};

		var actual = Map.MapComposite<C128_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredRateTypeCodeQualifier(string rateTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.UnitPriceBasisRate = "K";
		//Test Parameters
		subject.RateTypeCodeQualifier = rateTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredUnitPriceBasisRate(string unitPriceBasisRate, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RateTypeCodeQualifier = "C";
		//Test Parameters
		subject.UnitPriceBasisRate = unitPriceBasisRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
