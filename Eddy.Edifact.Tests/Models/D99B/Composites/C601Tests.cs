using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C601Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:A:o";

		var expected = new C601_StatusCategory()
		{
			StatusCategoryCoded = "M",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "o",
		};

		var actual = Map.MapComposite<C601_StatusCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredStatusCategoryCoded(string statusCategoryCoded, bool isValidExpected)
	{
		var subject = new C601_StatusCategory();
		//Required fields
		//Test Parameters
		subject.StatusCategoryCoded = statusCategoryCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
