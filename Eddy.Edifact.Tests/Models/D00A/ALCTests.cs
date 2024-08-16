using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ALCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALC+f++9+x+";

		var expected = new ALC_AllowanceOrCharge()
		{
			AllowanceOrChargeCodeQualifier = "f",
			AllowanceChargeInformation = null,
			SettlementMeansCode = "9",
			CalculationSequenceCode = "x",
			SpecialServicesIdentification = null,
		};

		var actual = Map.MapObject<ALC_AllowanceOrCharge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredAllowanceOrChargeCodeQualifier(string allowanceOrChargeCodeQualifier, bool isValidExpected)
	{
		var subject = new ALC_AllowanceOrCharge();
		//Required fields
		//Test Parameters
		subject.AllowanceOrChargeCodeQualifier = allowanceOrChargeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
