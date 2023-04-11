using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OD*NzcP8p*Xl2SHL*7T*VV";

		var expected = new OD_OriginAndDestination()
		{
			StandardPointLocationCode = "NzcP8p",
			StandardPointLocationCode2 = "Xl2SHL",
			StandardCarrierAlphaCode = "7T",
			StandardCarrierAlphaCode2 = "VV",
		};

		var actual = Map.MapObject<OD_OriginAndDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NzcP8p", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new OD_OriginAndDestination();
		subject.StandardPointLocationCode2 = "Xl2SHL";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xl2SHL", true)]
	public void Validation_RequiredStandardPointLocationCode2(string standardPointLocationCode2, bool isValidExpected)
	{
		var subject = new OD_OriginAndDestination();
		subject.StandardPointLocationCode = "NzcP8p";
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
