using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class XGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XG*IL*5*e*5*t*dCb";

		var expected = new XG_SwitchCharges()
		{
			RateValueQualifier = "IL",
			Rate = 5,
			WeightQualifier = "e",
			Weight = 5,
			Charge = "t",
			SpecialChargeOrAllowanceCode = "dCb",
		};

		var actual = Map.MapObject<XG_SwitchCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new XG_SwitchCharges();
		//Required fields
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
