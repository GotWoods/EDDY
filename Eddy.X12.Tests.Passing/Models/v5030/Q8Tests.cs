using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class Q8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q8*2*YAd*8*Gb*V*W*yK*f*9*t";

		var expected = new Q8_DetailDeliveryExceptionInformation()
		{
			LadingExceptionCode = "2",
			PackagingFormCode = "YAd",
			LadingQuantity = 8,
			ProductServiceIDQualifier = "Gb",
			ProductServiceID = "V",
			LadingDescription = "W",
			DamageReasonCode = "yK",
			ActionCode = "f",
			ReferenceIdentification = "9",
			Description = "t",
		};

		var actual = Map.MapObject<Q8_DetailDeliveryExceptionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		//Test Parameters
		subject.LadingExceptionCode = ladingExceptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "YAd";
			subject.LadingQuantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Gb";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("YAd", 8, true)]
	[InlineData("YAd", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "2";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Gb";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gb", "V", true)]
	[InlineData("Gb", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "2";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "YAd";
			subject.LadingQuantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
