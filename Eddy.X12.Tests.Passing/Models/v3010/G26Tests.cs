using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G26*Bw*Nt*gSMqay*FkZ*9*LZ";

		var expected = new G26_PricingConditions()
		{
			PriceConditionCode = "Bw",
			DateQualifier = "Nt",
			Date = "gSMqay",
			QuantityBasis = "FkZ",
			Quantity = 9,
			UnitOfMeasurementCode = "LZ",
		};

		var actual = Map.MapObject<G26_PricingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bw", true)]
	public void Validation_RequiredPriceConditionCode(string priceConditionCode, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = priceConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
