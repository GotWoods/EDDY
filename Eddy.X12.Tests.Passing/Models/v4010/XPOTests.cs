using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class XPOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XPO*t*l*2*4D";

		var expected = new XPO_PreassignedPurchaseOrderNumbers()
		{
			PurchaseOrderNumber = "t",
			PurchaseOrderNumber2 = "l",
			IdentificationCodeQualifier = "2",
			IdentificationCode = "4D",
		};

		var actual = Map.MapObject<XPO_PreassignedPurchaseOrderNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new XPO_PreassignedPurchaseOrderNumbers();
		//Required fields
		//Test Parameters
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "2";
			subject.IdentificationCode = "4D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "4D", true)]
	[InlineData("2", "", false)]
	[InlineData("", "4D", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new XPO_PreassignedPurchaseOrderNumbers();
		//Required fields
		subject.PurchaseOrderNumber = "t";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
