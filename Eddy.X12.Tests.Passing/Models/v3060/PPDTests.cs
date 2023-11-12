using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PPDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPD*2*6T*t*v*M*mx*F*2*3*3*2*3*5";

		var expected = new PPD_PaymentPatternDetails()
		{
			PaymentPattern = "2",
			DateTimePeriodFormatQualifier = "6T",
			DateTimePeriod = "t",
			ReferenceIdentification = "v",
			ReferenceIdentification2 = "M",
			RatingCode = "mx",
			DateTimePeriod2 = "F",
			Number = 2,
			Number2 = 3,
			Number3 = 3,
			Number4 = 2,
			Number5 = 3,
			Number6 = 5,
		};

		var actual = Map.MapObject<PPD_PaymentPatternDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
