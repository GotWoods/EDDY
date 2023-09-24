using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OBI*wu*N*3*8*Q*8";

		var expected = new OBI_ObligationInformation()
		{
			ObligationTypeCode = "wu",
			Name = "N",
			MonetaryAmount = 3,
			MonetaryAmount2 = 8,
			FrequencyCode = "Q",
			Quantity = 8,
		};

		var actual = Map.MapObject<OBI_ObligationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wu", true)]
	public void Validation_RequiredObligationTypeCode(string obligationTypeCode, bool isValidExpected)
	{
		var subject = new OBI_ObligationInformation();
		subject.ObligationTypeCode = obligationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
