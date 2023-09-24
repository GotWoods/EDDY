using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRA*wK*o";

		var expected = new RRA_RequiredResponse()
		{
			InformationType = "wK",
			ReferenceIdentification = "o",
		};

		var actual = Map.MapObject<RRA_RequiredResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wK", true)]
	public void Validation_RequiredInformationType(string informationType, bool isValidExpected)
	{
		var subject = new RRA_RequiredResponse();
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
