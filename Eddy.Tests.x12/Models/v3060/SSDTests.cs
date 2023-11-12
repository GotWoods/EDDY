using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSD*2*d*s*T";

		var expected = new SSD_ShipmentSortSegregateData()
		{
			ReferenceIdentification = "2",
			ReferenceIdentification2 = "d",
			PurchaseOrderNumber = "s",
			ApplicationErrorConditionCode = "T",
		};

		var actual = Map.MapObject<SSD_ShipmentSortSegregateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "s", true)]
	[InlineData("T", "", false)]
	[InlineData("", "s", true)]
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
