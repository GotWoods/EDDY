using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRA*9W*n";

		var expected = new RRA_RequiredResponse()
		{
			InformationType = "9W",
			ReferenceIdentification = "n",
		};

		var actual = Map.MapObject<RRA_RequiredResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9W", true)]
	public void Validation_RequiredInformationType(string informationType, bool isValidExpected)
	{
		var subject = new RRA_RequiredResponse();
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
