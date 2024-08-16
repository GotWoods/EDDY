using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C948Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:5:h:d";

		var expected = new C948_EmploymentCategory()
		{
			EmploymentCategoryDescriptionCode = "S",
			CodeListIdentificationCode = "5",
			CodeListResponsibleAgencyCode = "h",
			EmploymentCategoryDescription = "d",
		};

		var actual = Map.MapComposite<C948_EmploymentCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
