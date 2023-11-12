using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class INJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INJ*c*r*c*J*8Q*wS*HN*Ma*Ll*tiXXm*7nB";

		var expected = new INJ_InjuryOrIllnessDetail()
		{
			YesNoConditionOrResponseCode = "c",
			LocationIdentifier = "r",
			YesNoConditionOrResponseCode2 = "c",
			YesNoConditionOrResponseCode3 = "J",
			CauseOfInjuryCode = "8Q",
			NatureOfInjuryCode = "wS",
			PartOfBodyCode = "HN",
			SourceOfInjuryCode = "Ma",
			InitialTreatmentCode = "Ll",
			CountyDesignator = "tiXXm",
			PostalCode = "7nB",
		};

		var actual = Map.MapObject<INJ_InjuryOrIllnessDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
