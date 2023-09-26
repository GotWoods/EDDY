using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAD*1Yx*7*x*9*8*C*T";

		var expected = new SAD_StudentAwardDetail()
		{
			StatusReasonCode = "1Yx",
			InterestRate = 7,
			LoanRateTypeCode = "x",
			PaymentMethodCode = "9",
			Quantity = 8,
			CodeListQualifierCode = "C",
			IndustryCode = "T",
		};

		var actual = Map.MapObject<SAD_StudentAwardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "T", true)]
	[InlineData("C", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SAD_StudentAwardDetail();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
