using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C948Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:1:D:U";

		var expected = new C948_EmploymentCategory()
		{
			EmploymentCategoryCoded = "4",
			CodeListQualifier = "1",
			CodeListResponsibleAgencyCoded = "D",
			EmploymentCategory = "U",
		};

		var actual = Map.MapComposite<C948_EmploymentCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
