using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C601Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:X:2";

		var expected = new C601_StatusCategory()
		{
			StatusCategoryCoded = "h",
			CodeListQualifier = "X",
			CodeListResponsibleAgencyCoded = "2",
		};

		var actual = Map.MapComposite<C601_StatusCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredStatusCategoryCoded(string statusCategoryCoded, bool isValidExpected)
	{
		var subject = new C601_StatusCategory();
		//Required fields
		//Test Parameters
		subject.StatusCategoryCoded = statusCategoryCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
