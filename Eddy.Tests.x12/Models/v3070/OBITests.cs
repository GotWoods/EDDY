using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class OBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OBI*HV*V*1*8*M*5";

		var expected = new OBI_ObligationInformation()
		{
			ObligationTypeCode = "HV",
			Name = "V",
			MonetaryAmount = 1,
			MonetaryAmount2 = 8,
			FrequencyCode = "M",
			Quantity = 5,
		};

		var actual = Map.MapObject<OBI_ObligationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HV", true)]
	public void Validation_RequiredObligationTypeCode(string obligationTypeCode, bool isValidExpected)
	{
		var subject = new OBI_ObligationInformation();
		//Required fields
		//Test Parameters
		subject.ObligationTypeCode = obligationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
