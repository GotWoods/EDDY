using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FRM*L*v*0*wmcvO77t*6";

		var expected = new FRM_SupportingDocumentation()
		{
			AssignedIdentification = "L",
			YesNoConditionOrResponseCode = "v",
			ReferenceIdentification = "0",
			Date = "wmcvO77t",
			PercentDecimalFormat = 6,
		};

		var actual = Map.MapObject<FRM_SupportingDocumentation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new FRM_SupportingDocumentation();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
