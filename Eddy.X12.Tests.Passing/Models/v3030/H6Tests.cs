using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class H6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H6*BH*yi*2*y*8*x";

		var expected = new H6_SpecialServices()
		{
			SpecialServicesCode = "BH",
			SpecialServicesCode2 = "yi",
			QuantityOfPalletsShipped = 2,
			PalletExchangeCode = "y",
			Weight = 8,
			WeightUnitCode = "x",
		};

		var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("BH", "yi", true)]
	[InlineData("BH", "", true)]
	[InlineData("", "yi", true)]
	public void Validation_AtLeastOneSpecialServicesCode(string specialServicesCode, string specialServicesCode2, bool isValidExpected)
	{
		var subject = new H6_SpecialServices();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode = specialServicesCode;
		subject.SpecialServicesCode2 = specialServicesCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
