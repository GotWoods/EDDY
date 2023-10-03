using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C046Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "MN*wW*Ar*wo*9p";

		var expected = new C046_CompositeQualifierIdentifier()
		{
			RateValueQualifier = "MN",
			RateValueQualifier2 = "wW",
			RateValueQualifier3 = "Ar",
			RateValueQualifier4 = "wo",
			RateValueQualifier5 = "9p",
		};

		var actual = Map.MapObject<C046_CompositeQualifierIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MN", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new C046_CompositeQualifierIdentifier();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
