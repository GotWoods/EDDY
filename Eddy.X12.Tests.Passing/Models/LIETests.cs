using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LIETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIE*Hv*v7*J*QM";

		var expected = new LIE_IndividualOrEventLocation()
		{
			LocationTypeCode = "Hv",
			ProximityCode = "v7",
			Description = "J",
			EntityIdentifierCode = "QM",
		};

		var actual = Map.MapObject<LIE_IndividualOrEventLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hv", true)]
	public void Validation_RequiredLocationTypeCode(string locationTypeCode, bool isValidExpected)
	{
		var subject = new LIE_IndividualOrEventLocation();
		subject.LocationTypeCode = locationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
