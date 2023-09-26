using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*8*H*K*r*3*G*5WDtwr*37";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "8",
			YesNoConditionOrResponseCode2 = "H",
			YesNoConditionOrResponseCode3 = "K",
			YesNoConditionOrResponseCode4 = "r",
			ActionCode = "3",
			ReferenceIdentification = "G",
			Date = "5WDtwr",
			Century = 37,
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(37, "5WDtwr", true)]
	[InlineData(37, "", false)]
	[InlineData(0, "5WDtwr", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new BCU_LegalClaimUpdates();
		//Required fields
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
