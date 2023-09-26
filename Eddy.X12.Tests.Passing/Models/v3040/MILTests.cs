using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MILTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIL*t*H*agm*wtEOhd*jqc*fhgPLC*NM*3*a*l*ki*f";

		var expected = new MIL_Milestone()
		{
			MilestoneNumberIdentification = "t",
			Description = "H",
			DateTimeQualifier = "agm",
			Date = "wtEOhd",
			DateTimeQualifier2 = "jqc",
			Date2 = "fhgPLC",
			UnitOrBasisForMeasurementCode = "NM",
			Quantity = 3,
			WorkStatusCode = "a",
			ActionCode = "l",
			ReferenceNumberQualifier = "ki",
			ReferenceNumber = "f",
		};

		var actual = Map.MapObject<MIL_Milestone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredMilestoneNumberIdentification(string milestoneNumberIdentification, bool isValidExpected)
	{
		var subject = new MIL_Milestone();
		//Required fields
		//Test Parameters
		subject.MilestoneNumberIdentification = milestoneNumberIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
