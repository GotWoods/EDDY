using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIL*P*V*4Jp*kMRzL9*PMh*YmXzWs*2E*5*Y*m*tx*A";

		var expected = new MIL_Milestone()
		{
			MilestoneNumberIdentification = "P",
			Description = "V",
			DateTimeQualifier = "4Jp",
			Date = "kMRzL9",
			DateTimeQualifier2 = "PMh",
			Date2 = "YmXzWs",
			UnitOrBasisForMeasurementCode = "2E",
			Quantity = 5,
			WorkStatusCode = "Y",
			ActionCode = "m",
			ReferenceNumberQualifier = "tx",
			ReferenceNumber = "A",
		};

		var actual = Map.MapObject<MIL_Milestone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredMilestoneNumberIdentification(string milestoneNumberIdentification, bool isValidExpected)
	{
		var subject = new MIL_Milestone();
		//Required fields
		//Test Parameters
		subject.MilestoneNumberIdentification = milestoneNumberIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
