using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EC*Nz*dd*Ii*7*R*BDWV";

		var expected = new EC_EmploymentClass()
		{
			EmploymentClassCode = "Nz",
			EmploymentClassCode2 = "dd",
			EmploymentClassCode3 = "Ii",
			PercentageAsDecimal = 7,
			InformationStatusCode = "R",
			OccupationCode = "BDWV",
		};

		var actual = Map.MapObject<EC_EmploymentClass>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
