using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D2*O*v";

		var expected = new D2_ConsigneeAddress()
		{
			AdditionalNameAddressData = "O",
			AdditionalNameAddressData2 = "v",
		};

		var actual = Map.MapObject<D2_ConsigneeAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAdditionalNameAddressData(string additionalNameAddressData, bool isValidExpected)
	{
		var subject = new D2_ConsigneeAddress();
		subject.AdditionalNameAddressData = additionalNameAddressData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
