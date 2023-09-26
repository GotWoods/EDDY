using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*stKsrm8k*rcE7EXFH*0*A*s*5H*k*9*O";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "stKsrm8k",
			Date2 = "rcE7EXFH",
			RouteCode = "0",
			CarTypeCode = "A",
			IdentificationCodeQualifier = "s",
			IdentificationCode = "5H",
			ReferenceIdentification = "k",
			ConveyanceCode = "9",
			ReferenceIdentification2 = "O",
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "5H", true)]
	[InlineData("s", "", false)]
	[InlineData("", "5H", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PR2_PriceRequestParameterList2();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
