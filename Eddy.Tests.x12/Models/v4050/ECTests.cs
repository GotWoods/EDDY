using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EC*St*NI*5Z*5*J*HtQY";

		var expected = new EC_EmploymentClass()
		{
			EmploymentClassCode = "St",
			EmploymentClassCode2 = "NI",
			EmploymentClassCode3 = "5Z",
			PercentageAsDecimal = 5,
			InformationStatusCode = "J",
			OccupationCode = "HtQY",
		};

		var actual = Map.MapObject<EC_EmploymentClass>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
