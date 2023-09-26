using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEN*L*3*dO*B*2*sU";

		var expected = new BEN_BeneficiaryOrOwnerInformation()
		{
			PrimaryOrContingentCode = "L",
			Percent = 3,
			IndividualRelationshipCode = "dO",
			YesNoConditionOrResponseCode = "B",
			YesNoConditionOrResponseCode2 = "2",
			TypeOfAccount = "sU",
		};

		var actual = Map.MapObject<BEN_BeneficiaryOrOwnerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
