using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPD*y*eZ*y*0*I*ht*7*5*6*4*2*9*4";

		var expected = new PPD_PaymentPatternDetails()
		{
			PaymentPattern = "y",
			DateTimePeriodFormatQualifier = "eZ",
			DateTimePeriod = "y",
			ReferenceNumber = "0",
			ReferenceNumber2 = "I",
			RatingCode = "ht",
			DateTimePeriod2 = "7",
			Number = 5,
			Number2 = 6,
			Number3 = 4,
			Number4 = 2,
			Number5 = 9,
			Number6 = 4,
		};

		var actual = Map.MapObject<PPD_PaymentPatternDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
