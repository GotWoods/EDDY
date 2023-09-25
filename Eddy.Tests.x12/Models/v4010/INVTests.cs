using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INV*9*8*6*5*av*e*3";

		var expected = new INV_InvestmentVehicleSelection()
		{
			Description = "9",
			Percent = 8,
			MonetaryAmount = 6,
			Quantity = 5,
			StateOrProvinceCode = "av",
			Description2 = "e",
			MonetaryAmount2 = 3,
		};

		var actual = Map.MapObject<INV_InvestmentVehicleSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		//Required fields
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
