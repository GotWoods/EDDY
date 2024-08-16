using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C948Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:s:z:8";

		var expected = new C948_EmploymentCategory()
		{
			EmploymentCategoryDescriptionCode = "K",
			CodeListIdentificationCode = "s",
			CodeListResponsibleAgencyCode = "z",
			EmploymentCategoryDescription = "8",
		};

		var actual = Map.MapComposite<C948_EmploymentCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
