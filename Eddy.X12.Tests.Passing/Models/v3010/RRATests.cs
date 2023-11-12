using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRA*VJ*y";

		var expected = new RRA_RequiredResponse()
		{
			InformationType = "VJ",
			ReferenceNumber = "y",
		};

		var actual = Map.MapObject<RRA_RequiredResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VJ", true)]
	public void Validation_RequiredInformationType(string informationType, bool isValidExpected)
	{
		var subject = new RRA_RequiredResponse();
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
