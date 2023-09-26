using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIL*q*r*Cml*X5QcLX*Eix*ACzH1S**1*k*e*J4*M";

		var expected = new MIL_Milestone()
		{
			MilestoneNumberIdentification = "q",
			Description = "r",
			DateTimeQualifier = "Cml",
			Date = "X5QcLX",
			DateTimeQualifier2 = "Eix",
			Date2 = "ACzH1S",
			CompositeUnitOfMeasure = null,
			Quantity = 1,
			WorkStatusCode = "k",
			ActionCode = "e",
			ReferenceIdentificationQualifier = "J4",
			ReferenceIdentification = "M",
		};

		var actual = Map.MapObject<MIL_Milestone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredMilestoneNumberIdentification(string milestoneNumberIdentification, bool isValidExpected)
	{
		var subject = new MIL_Milestone();
		//Required fields
		//Test Parameters
		subject.MilestoneNumberIdentification = milestoneNumberIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
