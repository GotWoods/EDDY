using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*Q*S*c*d*2*r*QF43aY*26";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "Q",
			YesNoConditionOrResponseCode2 = "S",
			YesNoConditionOrResponseCode3 = "c",
			YesNoConditionOrResponseCode4 = "d",
			ActionCode = "2",
			ReferenceNumber = "r",
			Date = "QF43aY",
			Century = 26,
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(26, "QF43aY", true)]
	[InlineData(26, "", false)]
	[InlineData(0, "QF43aY", true)]
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
