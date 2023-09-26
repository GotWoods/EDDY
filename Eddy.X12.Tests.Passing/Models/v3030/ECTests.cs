using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EC*6t*uk*9I*2*u*TQuN";

		var expected = new EC_EmploymentClass()
		{
			EmploymentClassCode = "6t",
			EmploymentClassCode2 = "uk",
			EmploymentClassCode3 = "9I",
			Percent = 2,
			InformationStatusCode = "u",
			OccupationCode = "TQuN",
		};

		var actual = Map.MapObject<EC_EmploymentClass>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
