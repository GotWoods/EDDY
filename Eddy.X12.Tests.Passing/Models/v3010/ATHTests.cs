using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ATHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATH*MZ*wUU9NM*3*3*SvFAPJ";

		var expected = new ATH_ResourceAuthorization()
		{
			ResourceAuthorizationCode = "MZ",
			Date = "wUU9NM",
			Quantity = 3,
			Quantity2 = 3,
			Date2 = "SvFAPJ",
		};

		var actual = Map.MapObject<ATH_ResourceAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MZ", true)]
	public void Validation_RequiredResourceAuthorizationCode(string resourceAuthorizationCode, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = resourceAuthorizationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
