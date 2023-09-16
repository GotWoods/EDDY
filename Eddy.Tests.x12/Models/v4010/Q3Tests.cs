using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Q3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q3*Vw2Jmyo1*PS";

		var expected = new Q3_ArrivalDetails()
		{
			Date = "Vw2Jmyo1",
			ShipmentMethodOfPayment = "PS",
		};

		var actual = Map.MapObject<Q3_ArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vw2Jmyo1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ShipmentMethodOfPayment = "PS";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PS", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.Date = "Vw2Jmyo1";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
