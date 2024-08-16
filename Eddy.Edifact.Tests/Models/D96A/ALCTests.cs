using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ALCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALC+T++K+n+";

		var expected = new ALC_AllowanceOrCharge()
		{
			AllowanceOrChargeQualifier = "T",
			AllowanceChargeInformation = null,
			SettlementCoded = "K",
			CalculationSequenceIndicatorCoded = "n",
			SpecialServicesIdentification = null,
		};

		var actual = Map.MapObject<ALC_AllowanceOrCharge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAllowanceOrChargeQualifier(string allowanceOrChargeQualifier, bool isValidExpected)
	{
		var subject = new ALC_AllowanceOrCharge();
		//Required fields
		//Test Parameters
		subject.AllowanceOrChargeQualifier = allowanceOrChargeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
