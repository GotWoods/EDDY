using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C601Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:E:F";

		var expected = new C601_StatusCategory()
		{
			StatusCategoryCode = "S",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "F",
		};

		var actual = Map.MapComposite<C601_StatusCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredStatusCategoryCode(string statusCategoryCode, bool isValidExpected)
	{
		var subject = new C601_StatusCategory();
		//Required fields
		//Test Parameters
		subject.StatusCategoryCode = statusCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
