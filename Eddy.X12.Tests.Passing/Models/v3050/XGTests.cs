using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XG*du*9*f*5*Y*Wrd";

		var expected = new XG_SwitchCharges()
		{
			RateValueQualifier = "du",
			Rate = 9,
			WeightQualifier = "f",
			Weight = 5,
			Amount = "Y",
			SpecialChargeOrAllowanceCode = "Wrd",
		};

		var actual = Map.MapObject<XG_SwitchCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new XG_SwitchCharges();
		//Required fields
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
