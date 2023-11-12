using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C056Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "C*S*f";

		var expected = new C056_CompositeRaceOrEthnicityInformation()
		{
			RaceOrEthnicityCode = "C",
			CodeListQualifierCode = "S",
			IndustryCode = "f",
		};

		var actual = Map.MapObject<C056_CompositeRaceOrEthnicityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "f", true)]
	[InlineData("S", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new C056_CompositeRaceOrEthnicityInformation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
