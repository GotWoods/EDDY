using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class H6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H6*P6*4c*4*h*6*c";

		var expected = new H6_SpecialServices()
		{
			SpecialServicesCode = "P6",
			SpecialServicesCode2 = "4c",
			QuantityOfPalletsShipped = 4,
			PalletExchangeCode = "h",
			Weight = 6,
			WeightUnitQualifier = "c",
		};

		var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P6", "4c", true)]
	[InlineData("P6", "", true)]
	[InlineData("", "4c", true)]
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
