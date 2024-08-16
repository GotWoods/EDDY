using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C601Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:O:D";

		var expected = new C601_StatusCategory()
		{
			StatusCategoryCode = "L",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "D",
		};

		var actual = Map.MapComposite<C601_StatusCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredStatusCategoryCode(string statusCategoryCode, bool isValidExpected)
	{
		var subject = new C601_StatusCategory();
		//Required fields
		//Test Parameters
		subject.StatusCategoryCode = statusCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
