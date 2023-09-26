using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class OBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OBI*kc*1*6*5*1*4";

		var expected = new OBI_ObligationInformation()
		{
			ObligationTypeCode = "kc",
			Name = "1",
			MonetaryAmount = 6,
			MonetaryAmount2 = 5,
			FrequencyCode = "1",
			Quantity = 4,
		};

		var actual = Map.MapObject<OBI_ObligationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kc", true)]
	public void Validation_RequiredObligationTypeCode(string obligationTypeCode, bool isValidExpected)
	{
		var subject = new OBI_ObligationInformation();
		//Required fields
		//Test Parameters
		subject.ObligationTypeCode = obligationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
