using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C056Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:k";

		var expected = new C056_DepartmentOrEmployeeDetails()
		{
			DepartmentOrEmployeeIdentification = "I",
			DepartmentOrEmployee = "k",
		};

		var actual = Map.MapComposite<C056_DepartmentOrEmployeeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
