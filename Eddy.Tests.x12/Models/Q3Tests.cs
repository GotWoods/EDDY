using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Q3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q3*n2MwbWaU*bL";

		var expected = new Q3_ArrivalDetails()
		{
			Date = "n2MwbWaU",
			ShipmentMethodOfPaymentCode = "bL",
		};

		var actual = Map.MapObject<Q3_ArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n2MwbWaU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ShipmentMethodOfPaymentCode = "bL";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bL", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.Date = "n2MwbWaU";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
