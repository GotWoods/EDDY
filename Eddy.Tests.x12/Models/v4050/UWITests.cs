using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class UWITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UWI*q*E*U6*G";

		var expected = new UWI_UnderwritingInformation()
		{
			UnderwritingMethodCode = "q",
			Name = "E",
			DispositionStatusCode = "U6",
			ReferenceIdentification = "G",
		};

		var actual = Map.MapObject<UWI_UnderwritingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredUnderwritingMethodCode(string underwritingMethodCode, bool isValidExpected)
	{
		var subject = new UWI_UnderwritingInformation();
		//Required fields
		//Test Parameters
		subject.UnderwritingMethodCode = underwritingMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
