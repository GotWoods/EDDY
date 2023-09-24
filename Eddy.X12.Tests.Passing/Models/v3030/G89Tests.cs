using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*3*1*QV*sxNB1K7jOtm7*rF*h*S9TswI5Kz0tP*7*4";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 3,
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "QV",
			UPCEANConsumerPackageCode = "sxNB1K7jOtm7",
			ProductServiceIDQualifier = "rF",
			ProductServiceID = "h",
			UPCCaseCode = "S9TswI5Kz0tP",
			ItemListCost = 7,
			Pack = 4,
		};

		var actual = Map.MapObject<G89_LineItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		if (directStoreDeliverySequenceNumber > 0)
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
