using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Q3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q3*IMdnb8*F5";

		var expected = new Q3_ArrivalDetails()
		{
			ETADate = "IMdnb8",
			ShipmentMethodOfPayment = "F5",
		};

		var actual = Map.MapObject<Q3_ArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IMdnb8", true)]
	public void Validation_RequiredETADate(string eTADate, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ShipmentMethodOfPayment = "F5";
		subject.ETADate = eTADate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F5", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new Q3_ArrivalDetails();
		subject.ETADate = "IMdnb8";
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
