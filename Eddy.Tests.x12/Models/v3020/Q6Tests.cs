using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Q6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q6*5*3*E*7*GEL*My*B*qP7*6u*N";

		var expected = new Q6_ShipmentDetails()
		{
			Weight = 5,
			WeightUnitQualifier = "3",
			WeightQualifier = "E",
			LadingQuantity = 7,
			PackagingFormCode = "GEL",
			ShipmentMethodOfPayment = "My",
			NetAmountDue = "B",
			CurrencyCode = "qP7",
			UnitOfTimePeriodCode = "6u",
			ServiceStandard = "N",
		};

		var actual = Map.MapObject<Q6_ShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6u", "N", true)]
	[InlineData("6u", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodCode(string unitOfTimePeriodCode, string serviceStandard, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.UnitOfTimePeriodCode = unitOfTimePeriodCode;
		subject.ServiceStandard = serviceStandard;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
