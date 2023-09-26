using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OD*HfWwCe*Ho1RXf*r3*T4";

		var expected = new OD_OriginAndDestination()
		{
			StandardPointLocationCode = "HfWwCe",
			StandardPointLocationCode2 = "Ho1RXf",
			StandardCarrierAlphaCode = "r3",
			StandardCarrierAlphaCode2 = "T4",
		};

		var actual = Map.MapObject<OD_OriginAndDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HfWwCe", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new OD_OriginAndDestination();
		//Required fields
		subject.StandardPointLocationCode2 = "Ho1RXf";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ho1RXf", true)]
	public void Validation_RequiredStandardPointLocationCode2(string standardPointLocationCode2, bool isValidExpected)
	{
		var subject = new OD_OriginAndDestination();
		//Required fields
		subject.StandardPointLocationCode = "HfWwCe";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
