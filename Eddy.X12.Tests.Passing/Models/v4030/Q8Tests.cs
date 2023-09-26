using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class Q8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q8*j*21z*5*GM*i*r*Pb*2*H*s";

		var expected = new Q8_DetailDeliveryExceptionInformation()
		{
			LadingExceptionCode = "j",
			PackagingFormCode = "21z",
			LadingQuantity = 5,
			ProductServiceIDQualifier = "GM",
			ProductServiceID = "i",
			LadingDescription = "r",
			DamageReasonCode = "Pb",
			ActionCode = "2",
			ReferenceIdentification = "H",
			Description = "s",
		};

		var actual = Map.MapObject<Q8_DetailDeliveryExceptionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		//Test Parameters
		subject.LadingExceptionCode = ladingExceptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "21z";
			subject.LadingQuantity = 5;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "GM";
			subject.ProductServiceID = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("21z", 5, true)]
	[InlineData("21z", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "j";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "GM";
			subject.ProductServiceID = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GM", "i", true)]
	[InlineData("GM", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "j";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "21z";
			subject.LadingQuantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
