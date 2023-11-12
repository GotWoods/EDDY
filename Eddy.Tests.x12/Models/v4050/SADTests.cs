using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAD*TbG*2*D*z*5*X*U";

		var expected = new SAD_StudentAwardDetail()
		{
			StatusReasonCode = "TbG",
			InterestRate = 2,
			LoanRateTypeCode = "D",
			PaymentMethodTypeCode = "z",
			Quantity = 5,
			CodeListQualifierCode = "X",
			IndustryCode = "U",
		};

		var actual = Map.MapObject<SAD_StudentAwardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "U", true)]
	[InlineData("X", "", false)]
	[InlineData("", "U", false)]
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
