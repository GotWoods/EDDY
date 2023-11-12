using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010;
using Eddy.x12.Models.v6010.Composites;

namespace Eddy.x12.Tests.Models.v6010.Composites;

public class C061Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "2*Q";

		var expected = new C061_MemberHealthAndTreatmentInformation()
		{
			HealthRelatedCode = "2",
			YesNoConditionOrResponseCode = "Q",
		};

		var actual = Map.MapObject<C061_MemberHealthAndTreatmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
