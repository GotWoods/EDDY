using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class Q3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q3*jKBFXtc1*Jb";

		var expected = new Q3_ArrivalDetails()
		{
			Date = "jKBFXtc1",
			ShipmentMethodOfPaymentCode = "Jb",
		};

		var actual = Map.MapObject<Q3_ArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jKBFXtc1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ShipmentMethodOfPaymentCode = "Jb";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.Date = "jKBFXtc1";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
