using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*swQ5sfo1*7iJNMZuT*Q*z*t*as*O*Z*F";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "swQ5sfo1",
			Date2 = "7iJNMZuT",
			RouteCode = "Q",
			CarTypeCode = "z",
			IdentificationCodeQualifier = "t",
			IdentificationCode = "as",
			ReferenceIdentification = "O",
			ConveyanceCode = "Z",
			ReferenceIdentification2 = "F",
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "as", true)]
	[InlineData("t", "", false)]
	[InlineData("", "as", false)]
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
