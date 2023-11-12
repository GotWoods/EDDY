using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSD*y*j*4*j";

		var expected = new SSD_ShipmentSortSegregateData()
		{
			ReferenceIdentification = "y",
			ReferenceIdentification2 = "j",
			PurchaseOrderNumber = "4",
			ApplicationErrorConditionCode = "j",
		};

		var actual = Map.MapObject<SSD_ShipmentSortSegregateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "4", true)]
	[InlineData("j", "", false)]
	[InlineData("", "4", true)]
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
