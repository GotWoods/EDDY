using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INV*a*9*5*8*sn*j*2";

		var expected = new INV_InvestmentVehicleSelection()
		{
			Description = "a",
			Percent = 9,
			MonetaryAmount = 5,
			Quantity = 8,
			StateOrProvinceCode = "sn",
			Description2 = "j",
			MonetaryAmount2 = 2,
		};

		var actual = Map.MapObject<INV_InvestmentVehicleSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		//Required fields
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
