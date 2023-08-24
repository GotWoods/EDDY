using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ATHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATH*Sl*oYAtK6*6*7*3dwu1g";

		var expected = new ATH_ResourceAuthorization()
		{
			ResourceAuthorizationCode = "Sl",
			Date = "oYAtK6",
			Quantity = 6,
			Quantity2 = 7,
			Date2 = "3dwu1g",
		};

		var actual = Map.MapObject<ATH_ResourceAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sl", true)]
	public void Validation_RequiredResourceAuthorizationCode(string resourceAuthorizationCode, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = resourceAuthorizationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
