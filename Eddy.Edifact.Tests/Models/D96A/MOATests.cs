using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MOA+";

		var expected = new MOA_MonetaryAmount()
		{
			MonetaryAmount = null,
		};

		var actual = Map.MapObject<MOA_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMonetaryAmount(string monetaryAmount, bool isValidExpected)
	{
		var subject = new MOA_MonetaryAmount();
		//Required fields
		//Test Parameters
		if (monetaryAmount != "") 
			subject.MonetaryAmount = new C516_MonetaryAmount();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
