using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Q8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q8*o*y2F*8*7L*2*F*lH*C*V*Y";

		var expected = new Q8_DetailDeliveryExceptionInformation()
		{
			LadingExceptionCode = "o",
			PackagingFormCode = "y2F",
			LadingQuantity = 8,
			ProductServiceIDQualifier = "7L",
			ProductServiceID = "2",
			LadingDescription = "F",
			DamageReasonCode = "lH",
			ActionCode = "C",
			ReferenceNumber = "V",
			Description = "Y",
		};

		var actual = Map.MapObject<Q8_DetailDeliveryExceptionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		//Test Parameters
		subject.LadingExceptionCode = ladingExceptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "y2F";
			subject.LadingQuantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "7L";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y2F", 8, true)]
	[InlineData("y2F", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "o";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "7L";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7L", "2", true)]
	[InlineData("7L", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "o";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "y2F";
			subject.LadingQuantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
