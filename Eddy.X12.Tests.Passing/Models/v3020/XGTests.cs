using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class XGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XG*6e*2*V*6*9*zsY";

		var expected = new XG_SwitchCharges()
		{
			RateValueQualifier = "6e",
			Rate = 2,
			WeightQualifier = "V",
			Weight = 6,
			Charge = "9",
			SpecialChargeOrAllowanceCode = "zsY",
		};

		var actual = Map.MapObject<XG_SwitchCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new XG_SwitchCharges();
		//Required fields
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
