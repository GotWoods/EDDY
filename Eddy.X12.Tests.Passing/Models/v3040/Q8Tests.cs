using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class Q8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q8*m*vy9*8*Ql*T*e*dy*n*C*r";

		var expected = new Q8_DetailDeliveryExceptionInformation()
		{
			LadingExceptionCode = "m",
			PackagingFormCode = "vy9",
			LadingQuantity = 8,
			ProductServiceIDQualifier = "Ql",
			ProductServiceID = "T",
			LadingDescription = "e",
			DamageReasonCode = "dy",
			ActionCode = "n",
			ReferenceNumber = "C",
			Description = "r",
		};

		var actual = Map.MapObject<Q8_DetailDeliveryExceptionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		//Test Parameters
		subject.LadingExceptionCode = ladingExceptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "vy9";
			subject.LadingQuantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ql";
			subject.ProductServiceID = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("vy9", 8, true)]
	[InlineData("vy9", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "m";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ql";
			subject.ProductServiceID = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ql", "T", true)]
	[InlineData("Ql", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new Q8_DetailDeliveryExceptionInformation();
		//Required fields
		subject.LadingExceptionCode = "m";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.LadingQuantity > 0)
		{
			subject.PackagingFormCode = "vy9";
			subject.LadingQuantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
