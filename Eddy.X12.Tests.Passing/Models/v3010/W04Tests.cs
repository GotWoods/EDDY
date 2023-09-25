using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W04*4*w4*Cu5TlFpxrZL8*aS*j*2K*H*LH*D*e*9*598897*oN";

		var expected = new W04_ItemDetailTotal()
		{
			NumberOfUnitsShipped = 4,
			UnitOfMeasurementCode = "w4",
			UPCCaseCode = "Cu5TlFpxrZL8",
			ProductServiceIDQualifier = "aS",
			ProductServiceID = "j",
			ProductServiceIDQualifier2 = "2K",
			ProductServiceID2 = "H",
			FreightClassCode = "LH",
			RateClassCode = "D",
			CommodityCodeQualifier = "e",
			CommodityCode = "9",
			PalletBlockAndTiers = 598897,
			InboundConditionHoldCode = "oN",
		};

		var actual = Map.MapObject<W04_ItemDetailTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		//Required fields
		subject.UnitOfMeasurementCode = "w4";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w4", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		//Required fields
		subject.NumberOfUnitsShipped = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
