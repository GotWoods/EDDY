using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*PynNU5*2cXXmQ*q*EyDN*5*x9*r*N*V*57*54";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "PynNU5",
			Date2 = "2cXXmQ",
			RouteCode = "q",
			CarTypeCode = "EyDN",
			IdentificationCodeQualifier = "5",
			IdentificationCode = "x9",
			ReferenceNumber = "r",
			ConveyanceCode = "N",
			ReferenceNumber2 = "V",
			Century = 57,
			Century2 = 54,
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "x9", true)]
	[InlineData("5", "", false)]
	[InlineData("", "x9", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PR2_PriceRequestParameterList2();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(57, "PynNU5", true)]
	[InlineData(57, "", false)]
	[InlineData(0, "PynNU5", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new PR2_PriceRequestParameterList2();
		//Required fields
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(54, "2cXXmQ", true)]
	[InlineData(54, "", false)]
	[InlineData(0, "2cXXmQ", true)]
	public void Validation_ARequiresBCentury2(int century2, string date2, bool isValidExpected)
	{
		var subject = new PR2_PriceRequestParameterList2();
		//Required fields
		//Test Parameters
		if (century2 > 0) 
			subject.Century2 = century2;
		subject.Date2 = date2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
