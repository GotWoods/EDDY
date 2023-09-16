using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Q3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q3*aRKXUU*D6";

		var expected = new Q3_ArrivalDetails()
		{
			Date = "aRKXUU",
			ShipmentMethodOfPayment = "D6",
		};

		var actual = Map.MapObject<Q3_ArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aRKXUU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ShipmentMethodOfPayment = "D6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D6", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.Date = "aRKXUU";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
