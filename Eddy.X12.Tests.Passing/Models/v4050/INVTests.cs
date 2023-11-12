using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INV*s*8*4*3*D7*3*1";

		var expected = new INV_InvestmentVehicleSelection()
		{
			Description = "s",
			PercentageAsDecimal = 8,
			MonetaryAmount = 4,
			Quantity = 3,
			StateOrProvinceCode = "D7",
			Description2 = "3",
			MonetaryAmount2 = 1,
		};

		var actual = Map.MapObject<INV_InvestmentVehicleSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		//Required fields
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
