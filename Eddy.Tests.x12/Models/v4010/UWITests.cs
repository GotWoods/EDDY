using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class UWITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UWI*A*4*Fd*4";

		var expected = new UWI_UnderwritingInformation()
		{
			UnderwritingMethodCode = "A",
			Name = "4",
			DispositionCode = "Fd",
			ReferenceIdentification = "4",
		};

		var actual = Map.MapObject<UWI_UnderwritingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredUnderwritingMethodCode(string underwritingMethodCode, bool isValidExpected)
	{
		var subject = new UWI_UnderwritingInformation();
		//Required fields
		//Test Parameters
		subject.UnderwritingMethodCode = underwritingMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
