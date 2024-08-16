using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C056Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:D";

		var expected = new C056_DepartmentOrEmployeeDetails()
		{
			DepartmentOrEmployeeNameCode = "a",
			DepartmentOrEmployeeName = "D",
		};

		var actual = Map.MapComposite<C056_DepartmentOrEmployeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
