using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UWITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UWI*f*N*1U*X";

		var expected = new UWI_UnderwritingInformation()
		{
			UnderwritingMethodCode = "f",
			Name = "N",
			DispositionStatusCode = "1U",
			ReferenceIdentification = "X",
		};

		var actual = Map.MapObject<UWI_UnderwritingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredUnderwritingMethodCode(string underwritingMethodCode, bool isValidExpected)
	{
		var subject = new UWI_UnderwritingInformation();
		subject.UnderwritingMethodCode = underwritingMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
