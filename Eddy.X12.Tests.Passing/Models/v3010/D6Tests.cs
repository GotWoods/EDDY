using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D6*y*f";

		var expected = new D6_ConsigneesThirdPartyAddress()
		{
			AdditionalNameAddressData = "y",
			AdditionalNameAddressData2 = "f",
		};

		var actual = Map.MapObject<D6_ConsigneesThirdPartyAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAdditionalNameAddressData(string additionalNameAddressData, bool isValidExpected)
	{
		var subject = new D6_ConsigneesThirdPartyAddress();
		subject.AdditionalNameAddressData = additionalNameAddressData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
