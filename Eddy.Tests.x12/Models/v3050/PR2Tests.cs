using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PR2*WLVp0k*aAnuGv*d*c*a*5H*S*L*A*87*36";

		var expected = new PR2_PriceRequestParameterList2()
		{
			Date = "WLVp0k",
			Date2 = "aAnuGv",
			RouteCode = "d",
			CarTypeCode = "c",
			IdentificationCodeQualifier = "a",
			IdentificationCode = "5H",
			ReferenceNumber = "S",
			ConveyanceCode = "L",
			ReferenceNumber2 = "A",
			Century = 87,
			Century2 = 36,
		};

		var actual = Map.MapObject<PR2_PriceRequestParameterList2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "5H", true)]
	[InlineData("a", "", false)]
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

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(87, "WLVp0k", true)]
	[InlineData(87, "", false)]
	[InlineData(0, "WLVp0k", true)]
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
			subject.IdentificationCodeQualifier = "a";
			subject.IdentificationCode = "5H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(36, "aAnuGv", true)]
	[InlineData(36, "", false)]
	[InlineData(0, "aAnuGv", true)]
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
			subject.IdentificationCodeQualifier = "a";
			subject.IdentificationCode = "5H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
