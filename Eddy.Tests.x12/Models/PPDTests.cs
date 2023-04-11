using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPD*g*Vd*5*Q*6*G2*7*8*2*6*5*1*6";

		var expected = new PPD_PaymentPatternDetails()
		{
			PaymentPattern = "g",
			DateTimePeriodFormatQualifier = "Vd",
			DateTimePeriod = "5",
			ReferenceIdentification = "Q",
			ReferenceIdentification2 = "6",
			RatingCode = "G2",
			DateTimePeriod2 = "7",
			Number = 8,
			Number2 = 2,
			Number3 = 6,
			Number4 = 5,
			Number5 = 1,
			Number6 = 6,
		};

		var actual = Map.MapObject<PPD_PaymentPatternDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
