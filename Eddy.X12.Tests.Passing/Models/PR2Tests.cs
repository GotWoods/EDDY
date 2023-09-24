using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*Cq46jVa3*k0mqwmc8*P*d*z*cj*h*1*e";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "Cq46jVa3",
			Date2 = "k0mqwmc8",
			RouteCode = "P",
			CarTypeCode = "d",
			IdentificationCodeQualifier = "z",
			IdentificationCode = "cj",
			ReferenceIdentification = "h",
			ConveyanceCode = "1",
			ReferenceIdentification2 = "e",
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z", "cj", true)]
	[InlineData("", "cj", false)]
	[InlineData("z", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PR2_PriceRequestParameterList2();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
