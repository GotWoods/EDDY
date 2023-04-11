using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Q8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q8*S*vjF*2*ei*w*B*W8*s*z*6";

		var expected = new Q8_DetailDeliveryExceptionInformation()
		{
			LadingExceptionCode = "S",
			PackagingFormCode = "vjF",
			LadingQuantity = 2,
			ProductServiceIDQualifier = "ei",
			ProductServiceID = "w",
			LadingDescription = "B",
			DamageReasonCode = "W8",
			ActionCode = "s",
			ReferenceIdentification = "z",
			Description = "6",
		};

		var actual = Map.MapObject<Q8_DetailDeliveryExceptionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		subject.LadingExceptionCode = ladingExceptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("vjF", 2, true)]
	[InlineData("", 2, false)]
	[InlineData("vjF", 0, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		subject.LadingExceptionCode = "S";
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0)
		subject.LadingQuantity = ladingQuantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ei", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("ei", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		subject.LadingExceptionCode = "S";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
