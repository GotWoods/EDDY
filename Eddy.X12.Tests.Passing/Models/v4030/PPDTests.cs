using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPD*m*Vb*1*m*t*Ap*b*1*8*5*5*2*7";

		var expected = new PPD_PaymentPatternDetails()
		{
			PaymentPattern = "m",
			DateTimePeriodFormatQualifier = "Vb",
			DateTimePeriod = "1",
			ReferenceIdentification = "m",
			ReferenceIdentification2 = "t",
			RatingCode = "Ap",
			DateTimePeriod2 = "b",
			Number = 1,
			Number2 = 8,
			Number3 = 5,
			Number4 = 5,
			Number5 = 2,
			Number6 = 7,
		};

		var actual = Map.MapObject<PPD_PaymentPatternDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
