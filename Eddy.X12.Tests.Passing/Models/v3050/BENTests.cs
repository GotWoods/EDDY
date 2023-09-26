using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEN*V*6*GE*i*y*QW";

		var expected = new BEN_BeneficiaryOrOwnerInformation()
		{
			PrimaryOrContingentCode = "V",
			Percent = 6,
			IndividualRelationshipCode = "GE",
			YesNoConditionOrResponseCode = "i",
			YesNoConditionOrResponseCode2 = "y",
			TypeOfAccountCode = "QW",
		};

		var actual = Map.MapObject<BEN_BeneficiaryOrOwnerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
