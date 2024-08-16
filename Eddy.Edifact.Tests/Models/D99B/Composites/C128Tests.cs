using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C128Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:J:W:Y";

		var expected = new C128_RateDetails()
		{
			RateTypeQualifier = "f",
			RatePerUnit = "J",
			UnitPriceBasis = "W",
			MeasurementUnitCode = "Y",
		};

		var actual = Map.MapComposite<C128_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredRateTypeQualifier(string rateTypeQualifier, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RatePerUnit = "J";
		//Test Parameters
		subject.RateTypeQualifier = rateTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredRatePerUnit(string ratePerUnit, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RateTypeQualifier = "f";
		//Test Parameters
		subject.RatePerUnit = ratePerUnit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
