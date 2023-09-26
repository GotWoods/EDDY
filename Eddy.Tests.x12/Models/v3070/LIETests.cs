using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LIETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIE*sz*nm*O*Q6";

		var expected = new LIE_IndividualOrEventLocation()
		{
			LocationTypeCode = "sz",
			ProximityCode = "nm",
			Description = "O",
			EntityIdentifierCode = "Q6",
		};

		var actual = Map.MapObject<LIE_IndividualOrEventLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sz", true)]
	public void Validation_RequiredLocationTypeCode(string locationTypeCode, bool isValidExpected)
	{
		var subject = new LIE_IndividualOrEventLocation();
		//Required fields
		//Test Parameters
		subject.LocationTypeCode = locationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
