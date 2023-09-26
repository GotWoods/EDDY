using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class BENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEN*j*6*Dv*C*x*hQ";

		var expected = new BEN_BeneficiaryOrOwnerInformation()
		{
			PrimaryOrContingentCode = "j",
			PercentageAsDecimal = 6,
			IndividualRelationshipCode = "Dv",
			YesNoConditionOrResponseCode = "C",
			YesNoConditionOrResponseCode2 = "x",
			TypeOfAccountCode = "hQ",
		};

		var actual = Map.MapObject<BEN_BeneficiaryOrOwnerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
