using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BNXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNX*J*D*2*66181";

		var expected = new BNX_RailShipmentInformation()
		{
			ShipmentWeightCode = "J",
			ReferencedPatternIdentifier = "D",
			BillingCode = "2",
			RepetitivePatternNumber = 66181,
		};

		var actual = Map.MapObject<BNX_RailShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 66181, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 66181, false)]
	public void Validation_AllAreRequiredReferencedPatternIdentifier(string referencedPatternIdentifier, int repetitivePatternNumber, bool isValidExpected)
	{
		var subject = new BNX_RailShipmentInformation();
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
