using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FRM*N*p*P*lcpMPFus*4";

		var expected = new FRM_SupportingDocumentation()
		{
			AssignedIdentification = "N",
			YesNoConditionOrResponseCode = "p",
			ReferenceIdentification = "P",
			Date = "lcpMPFus",
			PercentDecimalFormat = 4,
		};

		var actual = Map.MapObject<FRM_SupportingDocumentation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new FRM_SupportingDocumentation();
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
