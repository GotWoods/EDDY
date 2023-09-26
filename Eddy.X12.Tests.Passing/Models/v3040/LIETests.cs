using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LIETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIE*NR*vD*W*fq";

		var expected = new LIE_IndividualOrEventLocation()
		{
			LocationTypeCode = "NR",
			ProximityCode = "vD",
			Description = "W",
			EntityIdentifierCode = "fq",
		};

		var actual = Map.MapObject<LIE_IndividualOrEventLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NR", true)]
	public void Validation_RequiredLocationTypeCode(string locationTypeCode, bool isValidExpected)
	{
		var subject = new LIE_IndividualOrEventLocation();
		//Required fields
		//Test Parameters
		subject.LocationTypeCode = locationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
