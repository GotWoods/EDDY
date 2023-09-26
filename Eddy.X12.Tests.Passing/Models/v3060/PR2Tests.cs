using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*BmpOjd*WYBvBf*p*Q*H*Op*P*6*3*92*95";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "BmpOjd",
			Date2 = "WYBvBf",
			RouteCode = "p",
			CarTypeCode = "Q",
			IdentificationCodeQualifier = "H",
			IdentificationCode = "Op",
			ReferenceIdentification = "P",
			ConveyanceCode = "6",
			ReferenceIdentification2 = "3",
			Century = 92,
			Century2 = 95,
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "Op", true)]
	[InlineData("H", "", false)]
	[InlineData("", "Op", false)]
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
	[InlineData(92, "BmpOjd", true)]
	[InlineData(92, "", false)]
	[InlineData(0, "BmpOjd", true)]
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
			subject.IdentificationCodeQualifier = "H";
			subject.IdentificationCode = "Op";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(95, "WYBvBf", true)]
	[InlineData(95, "", false)]
	[InlineData(0, "WYBvBf", true)]
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
			subject.IdentificationCodeQualifier = "H";
			subject.IdentificationCode = "Op";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
