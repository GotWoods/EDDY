using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCT*Jl2*L6*5*4*cF*2*B*Pe";

		var expected = new MCT_TariffAccessorialCharges()
		{
			SpecialChargeCode = "Jl2",
			TariffValueCode = "L6",
			RangeMinimum = 5,
			RangeMaximum = 4,
			RateValueQualifier = "cF",
			SpecialCharge = 2,
			TariffReferenceFlag = "B",
			SpecialChargeDescription = "Pe",
		};

		var actual = Map.MapObject<MCT_TariffAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jl2", true)]
	public void Validation_RequiredSpecialChargeCode(string specialChargeCode, bool isValidExpected)
	{
		var subject = new MCT_TariffAccessorialCharges();
		subject.SpecialChargeCode = specialChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
