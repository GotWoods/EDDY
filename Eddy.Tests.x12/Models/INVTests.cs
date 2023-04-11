using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INV*m*7*5*6*hh*0*2";

		var expected = new INV_InvestmentVehicleSelection()
		{
			Description = "m",
			PercentageAsDecimal = 7,
			MonetaryAmount = 5,
			Quantity = 6,
			StateOrProvinceCode = "hh",
			Description2 = "0",
			MonetaryAmount2 = 2,
		};

		var actual = Map.MapObject<INV_InvestmentVehicleSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
