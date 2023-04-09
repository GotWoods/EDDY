using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEN*6*8*fM*n*k*uI";

		var expected = new BEN_BeneficiaryOrOwnerInformation()
		{
			PrimaryOrContingentCode = "6",
			PercentageAsDecimal = 8,
			IndividualRelationshipCode = "fM",
			YesNoConditionOrResponseCode = "n",
			YesNoConditionOrResponseCode2 = "k",
			TypeOfAccountCode = "uI",
		};

		var actual = Map.MapObject<BEN_BeneficiaryOrOwnerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

}
