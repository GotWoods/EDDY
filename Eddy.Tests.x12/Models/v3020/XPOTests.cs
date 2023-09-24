using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class XPOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XPO*v*z*X*lr";

		var expected = new XPO_PreassignedPurchaseOrderNumbers()
		{
			PurchaseOrderNumber = "v",
			PurchaseOrderNumber2 = "z",
			IdentificationCodeQualifier = "X",
			IdentificationCode = "lr",
		};

		var actual = Map.MapObject<XPO_PreassignedPurchaseOrderNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new XPO_PreassignedPurchaseOrderNumbers();
		//Required fields
		//Test Parameters
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "X";
			subject.IdentificationCode = "lr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "lr", true)]
	[InlineData("X", "", false)]
	[InlineData("", "lr", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new XPO_PreassignedPurchaseOrderNumbers();
		//Required fields
		subject.PurchaseOrderNumber = "v";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
