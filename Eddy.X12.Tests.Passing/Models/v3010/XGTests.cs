using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XG*O2*4*i*6*J*WZB";

		var expected = new XG_SwitchCharges()
		{
			RateValueQualifier = "O2",
			Rate = 4,
			WeightQualifier = "i",
			Weight = 6,
			Charge = "J",
			SpecialChargeCode = "WZB",
		};

		var actual = Map.MapObject<XG_SwitchCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new XG_SwitchCharges();
		//Required fields
		//Test Parameters
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
