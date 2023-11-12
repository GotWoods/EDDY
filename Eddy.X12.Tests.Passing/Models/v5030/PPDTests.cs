using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPD*m*s4*C*k*K*7h*X*8*7*1*1*6*2";

		var expected = new PPD_PaymentPatternDetails()
		{
			PaymentPattern = "m",
			DateTimePeriodFormatQualifier = "s4",
			DateTimePeriod = "C",
			ReferenceIdentification = "k",
			ReferenceIdentification2 = "K",
			RatingCode = "7h",
			DateTimePeriod2 = "X",
			Number = 8,
			Number2 = 7,
			Number3 = 1,
			Number4 = 1,
			Number5 = 6,
			Number6 = 2,
		};

		var actual = Map.MapObject<PPD_PaymentPatternDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
