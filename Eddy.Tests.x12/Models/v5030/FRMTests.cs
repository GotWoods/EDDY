using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FRM*s*U*q*5fvdxD8Q*4";

		var expected = new FRM_SupportingDocumentation()
		{
			AssignedIdentification = "s",
			YesNoConditionOrResponseCode = "U",
			ReferenceIdentification = "q",
			Date = "5fvdxD8Q",
			PercentDecimalFormat = 4,
		};

		var actual = Map.MapObject<FRM_SupportingDocumentation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new FRM_SupportingDocumentation();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
