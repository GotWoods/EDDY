using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*4*3*aS*3x2fDzwexmbV*uq*y*oC0bechsl3K9*5*8*1";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 4,
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "aS",
			UPCEANConsumerPackageCode = "3x2fDzwexmbV",
			ProductServiceIDQualifier = "uq",
			ProductServiceID = "y",
			UPCCaseCode = "oC0bechsl3K9",
			ItemListCost = 5,
			Pack = 8,
			InnerPack = 1,
		};

		var actual = Map.MapObject<G89_LineItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		if (directStoreDeliverySequenceNumber > 0)
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
