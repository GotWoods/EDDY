using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDS*Q*i*M*v";

		var expected = new TDS_TotalMonetaryValueSummary()
		{
			Amount = "Q",
			Amount2 = "i",
			Amount3 = "M",
			Amount4 = "v",
		};

		var actual = Map.MapObject<TDS_TotalMonetaryValueSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new TDS_TotalMonetaryValueSummary();
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
