using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C128Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:u:E:p";

		var expected = new C128_RateDetails()
		{
			RateTypeCodeQualifier = "T",
			UnitPriceBasisRate = "u",
			UnitPriceBasisValue = "E",
			MeasurementUnitCode = "p",
		};

		var actual = Map.MapComposite<C128_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredRateTypeCodeQualifier(string rateTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.UnitPriceBasisRate = "u";
		//Test Parameters
		subject.RateTypeCodeQualifier = rateTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredUnitPriceBasisRate(string unitPriceBasisRate, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RateTypeCodeQualifier = "T";
		//Test Parameters
		subject.UnitPriceBasisRate = unitPriceBasisRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
