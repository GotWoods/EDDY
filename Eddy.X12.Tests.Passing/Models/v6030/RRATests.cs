using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class RRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRA*BB*t";

		var expected = new RRA_RequiredResponse()
		{
			InformationTypeCode = "BB",
			ReferenceIdentification = "t",
		};

		var actual = Map.MapObject<RRA_RequiredResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BB", true)]
	public void Validation_RequiredInformationTypeCode(string informationTypeCode, bool isValidExpected)
	{
		var subject = new RRA_RequiredResponse();
		subject.InformationTypeCode = informationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
