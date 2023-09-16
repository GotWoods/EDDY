using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Q7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q7*u*RXG*1";

		var expected = new Q7_LadingExceptionCode()
		{
			LadingExceptionCode = "u",
			PackagingFormCode = "RXG",
			LadingQuantity = 1,
		};

		var actual = Map.MapObject<Q7_LadingExceptionCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q7_LadingExceptionCode();
		subject.LadingExceptionCode = ladingExceptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("RXG", 1, true)]
	[InlineData("RXG", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q7_LadingExceptionCode();
		subject.LadingExceptionCode = "u";
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
