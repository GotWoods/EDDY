using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*Z*W*4*Y*x*Z*XeaatAHP";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "Z",
			YesNoConditionOrResponseCode2 = "W",
			YesNoConditionOrResponseCode3 = "4",
			YesNoConditionOrResponseCode4 = "Y",
			ActionCode = "x",
			ReferenceIdentification = "Z",
			Date = "XeaatAHP",
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
