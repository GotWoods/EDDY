using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAD*6Lj*3*X*5*8*S*T";

		var expected = new SAD_StudentAwardDetail()
		{
			StatusReasonCode = "6Lj",
			InterestRate = 3,
			LoanRateTypeCode = "X",
			PaymentMethodTypeCode = "5",
			Quantity = 8,
			CodeListQualifierCode = "S",
			IndustryCode = "T",
		};

		var actual = Map.MapObject<SAD_StudentAwardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "T", true)]
	[InlineData("", "T", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SAD_StudentAwardDetail();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
