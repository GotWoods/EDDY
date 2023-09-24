using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class H6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H6*nb*pK*9*X*8*a*A";

		var expected = new H6_SpecialServices()
		{
			SpecialServicesCode = "nb",
			SpecialServicesCode2 = "pK",
			QuantityOfPalletsShipped = 9,
			PalletExchangeCode = "X",
			Weight = 8,
			WeightUnitCode = "a",
			PickupOrDeliveryCode = "A",
		};

		var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("nb", "A", true)]
	[InlineData("nb", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneSpecialServicesCode(string specialServicesCode, string pickupOrDeliveryCode, bool isValidExpected)
	{
		var subject = new H6_SpecialServices();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode = specialServicesCode;
		subject.PickupOrDeliveryCode = pickupOrDeliveryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pK", "nb", true)]
	[InlineData("pK", "", false)]
	[InlineData("", "nb", true)]
	public void Validation_ARequiresBSpecialServicesCode2(string specialServicesCode2, string specialServicesCode, bool isValidExpected)
	{
		var subject = new H6_SpecialServices();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode2 = specialServicesCode2;
		subject.SpecialServicesCode = specialServicesCode;
		//At Least one
		subject.PickupOrDeliveryCode = "A";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
