using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class UWITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UWI*T*w*sS*4";

		var expected = new UWI_UnderwritingInformation()
		{
			UnderwritingMethodCode = "T",
			Name = "w",
			DispositionStatusCode = "sS",
			ReferenceIdentification = "4",
		};

		var actual = Map.MapObject<UWI_UnderwritingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredUnderwritingMethodCode(string underwritingMethodCode, bool isValidExpected)
	{
		var subject = new UWI_UnderwritingInformation();
		//Required fields
		//Test Parameters
		subject.UnderwritingMethodCode = underwritingMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
