using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F2*G*s";

		var expected = new F2_ConsignorAddress()
		{
			AdditionalNameAddressData = "G",
			AdditionalNameAddressData2 = "s",
		};

		var actual = Map.MapObject<F2_ConsignorAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredAdditionalNameAddressData(string additionalNameAddressData, bool isValidExpected)
	{
		var subject = new F2_ConsignorAddress();
		subject.AdditionalNameAddressData = additionalNameAddressData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
