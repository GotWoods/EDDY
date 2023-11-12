using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSD*q*K*2*G";

		var expected = new SSD_ShipmentSortSegregateData()
		{
			ReferenceIdentification = "q",
			ReferenceIdentification2 = "K",
			PurchaseOrderNumber = "2",
			ApplicationErrorConditionCode = "G",
		};

		var actual = Map.MapObject<SSD_ShipmentSortSegregateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "2", true)]
	[InlineData("G", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBApplicationErrorConditionCode(string applicationErrorConditionCode, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new SSD_ShipmentSortSegregateData();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
