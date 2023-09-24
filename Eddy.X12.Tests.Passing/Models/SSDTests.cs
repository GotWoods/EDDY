using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSD*H*R*5*I";

		var expected = new SSD_ShipmentSortSegregateData()
		{
			ReferenceIdentification = "H",
			ReferenceIdentification2 = "R",
			PurchaseOrderNumber = "5",
			ApplicationErrorConditionCode = "I",
		};

		var actual = Map.MapObject<SSD_ShipmentSortSegregateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "5", true)]
	[InlineData("I", "", false)]
	public void Validation_ARequiresBApplicationErrorConditionCode(string applicationErrorConditionCode, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new SSD_ShipmentSortSegregateData();
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		subject.PurchaseOrderNumber = purchaseOrderNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
