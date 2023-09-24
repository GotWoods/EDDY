using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPT*0y*5b*Xm*eG**Ac*Fm*i";

		var expected = new SPT_SpiritAndLiqueurInformation()
		{
			SpiritTypeCode = "0y",
			SpiritStyle = "5b",
			Color = "Xm",
			LiqueurFlavor = "eG",
			CompositeAddedFlavor = null,
			DistilledFromSpiritType = "Ac",
			WhiskeyProductionType = "Fm",
			YesNoConditionOrResponseCode = "i",
		};

		var actual = Map.MapObject<SPT_SpiritAndLiqueurInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0y", true)]
	public void Validation_RequiredSpiritTypeCode(string spiritTypeCode, bool isValidExpected)
	{
		var subject = new SPT_SpiritAndLiqueurInformation();
		subject.SpiritTypeCode = spiritTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
