using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C128Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:f:S:Y";

		var expected = new C128_RateDetails()
		{
			RateTypeQualifier = "Z",
			RatePerUnit = "f",
			UnitPriceBasis = "S",
			MeasureUnitQualifier = "Y",
		};

		var actual = Map.MapComposite<C128_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredRateTypeQualifier(string rateTypeQualifier, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RatePerUnit = "f";
		//Test Parameters
		subject.RateTypeQualifier = rateTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredRatePerUnit(string ratePerUnit, bool isValidExpected)
	{
		var subject = new C128_RateDetails();
		//Required fields
		subject.RateTypeQualifier = "Z";
		//Test Parameters
		subject.RatePerUnit = ratePerUnit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
