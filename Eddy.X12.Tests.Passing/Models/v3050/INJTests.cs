using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class INJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INJ*4*R*m*D*VX*Bt*Mo*Yp*2g*mcftg*5fT";

		var expected = new INJ_InjuryOrIllnessDetail()
		{
			YesNoConditionOrResponseCode = "4",
			LocationIdentifier = "R",
			YesNoConditionOrResponseCode2 = "m",
			YesNoConditionOrResponseCode3 = "D",
			CauseOfInjuryCode = "VX",
			NatureOfInjuryCode = "Bt",
			PartOfBodyCode = "Mo",
			SourceOfInjuryCode = "Yp",
			InitialTreatmentCode = "2g",
			CountyDesignator = "mcftg",
			PostalCode = "5fT",
		};

		var actual = Map.MapObject<INJ_InjuryOrIllnessDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
