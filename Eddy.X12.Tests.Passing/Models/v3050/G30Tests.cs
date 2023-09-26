using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G30*z*5";

		var expected = new G30_StoreElectronicMarketingTypes()
		{
			ElectronicMarketingTypeCode = "z",
			Number = 5,
		};

		var actual = Map.MapObject<G30_StoreElectronicMarketingTypes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredElectronicMarketingTypeCode(string electronicMarketingTypeCode, bool isValidExpected)
	{
		var subject = new G30_StoreElectronicMarketingTypes();
		//Required fields
		//Test Parameters
		subject.ElectronicMarketingTypeCode = electronicMarketingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
