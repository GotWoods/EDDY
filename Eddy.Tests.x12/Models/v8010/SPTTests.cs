using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class SPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPT*XZ*FQ*uE*TA**3E*oe*P";

		var expected = new SPT_SpiritAndLiqueurInformation()
		{
			SpiritTypeCode = "XZ",
			SpiritStyle = "FQ",
			Color = "uE",
			LiqueurFlavor = "TA",
			CompositeAddedFlavor = null,
			DistilledFromSpiritType = "3E",
			WhiskeyProductionType = "oe",
			YesNoConditionOrResponseCode = "P",
		};

		var actual = Map.MapObject<SPT_SpiritAndLiqueurInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XZ", true)]
	public void Validation_RequiredSpiritTypeCode(string spiritTypeCode, bool isValidExpected)
	{
		var subject = new SPT_SpiritAndLiqueurInformation();
		//Required fields
		//Test Parameters
		subject.SpiritTypeCode = spiritTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
