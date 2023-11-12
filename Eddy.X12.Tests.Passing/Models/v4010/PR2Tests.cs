using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*SlYyI06e*UuXFJw4k*i*g*o*zF*u*t*4";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "SlYyI06e",
			Date2 = "UuXFJw4k",
			RouteCode = "i",
			CarTypeCode = "g",
			IdentificationCodeQualifier = "o",
			IdentificationCode = "zF",
			ReferenceIdentification = "u",
			ConveyanceCode = "t",
			ReferenceIdentification2 = "4",
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "zF", true)]
	[InlineData("o", "", false)]
	[InlineData("", "zF", false)]
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
