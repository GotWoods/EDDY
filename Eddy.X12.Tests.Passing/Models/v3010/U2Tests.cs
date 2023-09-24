using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class U2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "U2*q*k";

		var expected = new U2_UltimateConsigneeAddress()
		{
			AdditionalNameAddressData = "q",
			AdditionalNameAddressData2 = "k",
		};

		var actual = Map.MapObject<U2_UltimateConsigneeAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredAdditionalNameAddressData(string additionalNameAddressData, bool isValidExpected)
	{
		var subject = new U2_UltimateConsigneeAddress();
		subject.AdditionalNameAddressData = additionalNameAddressData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
