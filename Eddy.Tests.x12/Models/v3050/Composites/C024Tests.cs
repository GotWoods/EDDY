using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Tests.Models.v3050.Composites;

public class C024Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "5X*6a*Ka*kQ*qG";

		var expected = new C024_RelatedCausesInformation()
		{
			RelatedCausesCode = "5X",
			RelatedCausesCode2 = "6a",
			RelatedCausesCode3 = "Ka",
			StateOrProvinceCode = "kQ",
			CountryCode = "qG",
		};

		var actual = Map.MapObject<C024_RelatedCausesInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5X", true)]
	public void Validation_RequiredRelatedCausesCode(string relatedCausesCode, bool isValidExpected)
	{
		var subject = new C024_RelatedCausesInformation();
		//Required fields
		//Test Parameters
		subject.RelatedCausesCode = relatedCausesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
