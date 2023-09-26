using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class INJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INJ*S*2*6*Q*BD*c7*N5*Dm*xk*GVuut*hvV";

		var expected = new INJ_InjuryOrIllnessDetail()
		{
			YesNoConditionOrResponseCode = "S",
			LocationIdentifier = "2",
			YesNoConditionOrResponseCode2 = "6",
			YesNoConditionOrResponseCode3 = "Q",
			CauseOfInjuryCode = "BD",
			NatureOfInjuryCode = "c7",
			PartOfBodyCode = "N5",
			SourceOfInjuryCode = "Dm",
			InitialTreatmentCode = "xk",
			CountyDesignator = "GVuut",
			PostalCode = "hvV",
		};

		var actual = Map.MapObject<INJ_InjuryOrIllnessDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
