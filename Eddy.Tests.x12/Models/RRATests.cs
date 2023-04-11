using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRA*Yf*e";

		var expected = new RRA_RequiredResponse()
		{
			InformationTypeCode = "Yf",
			ReferenceIdentification = "e",
		};

		var actual = Map.MapObject<RRA_RequiredResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yf", true)]
	public void Validation_RequiredInformationTypeCode(string informationTypeCode, bool isValidExpected)
	{
		var subject = new RRA_RequiredResponse();
		subject.InformationTypeCode = informationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
