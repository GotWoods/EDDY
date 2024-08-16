using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C601Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:c:n";

		var expected = new C601_StatusType()
		{
			StatusTypeCoded = "G",
			CodeListQualifier = "c",
			CodeListResponsibleAgencyCoded = "n",
		};

		var actual = Map.MapComposite<C601_StatusType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredStatusTypeCoded(string statusTypeCoded, bool isValidExpected)
	{
		var subject = new C601_StatusType();
		//Required fields
		//Test Parameters
		subject.StatusTypeCoded = statusTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
