using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class OBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OBI*UK*X*2*2*x*2";

		var expected = new OBI_ObligationInformation()
		{
			ObligationTypeCode = "UK",
			Name = "X",
			MonetaryAmount = 2,
			MonetaryAmount2 = 2,
			FrequencyCode = "x",
			Quantity = 2,
		};

		var actual = Map.MapObject<OBI_ObligationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UK", true)]
	public void Validation_RequiredObligationTypeCode(string obligationTypeCode, bool isValidExpected)
	{
		var subject = new OBI_ObligationInformation();
		//Required fields
		//Test Parameters
		subject.ObligationTypeCode = obligationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
