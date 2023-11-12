using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class H6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H6*rg*JQ*6*j*3*y*h";

		var expected = new H6_SpecialServices()
		{
			SpecialServicesCode = "rg",
			SpecialServicesCode2 = "JQ",
			QuantityOfPalletsShipped = 6,
			PalletExchangeCode = "j",
			Weight = 3,
			WeightUnitCode = "y",
			PickUpOrDeliveryCode = "h",
		};

		var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("rg", "h", true)]
	[InlineData("rg", "", true)]
	[InlineData("", "h", true)]
	public void Validation_AtLeastOneSpecialServicesCode(string specialServicesCode, string pickUpOrDeliveryCode, bool isValidExpected)
	{
		var subject = new H6_SpecialServices();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode = specialServicesCode;
		subject.PickUpOrDeliveryCode = pickUpOrDeliveryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JQ", "rg", true)]
	[InlineData("JQ", "", false)]
	[InlineData("", "rg", true)]
	public void Validation_ARequiresBSpecialServicesCode2(string specialServicesCode2, string specialServicesCode, bool isValidExpected)
	{
		var subject = new H6_SpecialServices();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode2 = specialServicesCode2;
		subject.SpecialServicesCode = specialServicesCode;
		//At Least one
		subject.PickUpOrDeliveryCode = "h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
