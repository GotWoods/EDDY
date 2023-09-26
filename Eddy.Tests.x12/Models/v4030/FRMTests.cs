using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FRM*t*p*b*GG8Kk1VV*9";

		var expected = new FRM_SupportingDocumentation()
		{
			AssignedIdentification = "t",
			YesNoConditionOrResponseCode = "p",
			ReferenceIdentification = "b",
			Date = "GG8Kk1VV",
			Percent = 9,
		};

		var actual = Map.MapObject<FRM_SupportingDocumentation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new FRM_SupportingDocumentation();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
