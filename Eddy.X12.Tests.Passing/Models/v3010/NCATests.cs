using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class NCATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NCA*M*z*K*4*me";

		var expected = new NCA_NonconformanceAction()
		{
			AssignedIdentification = "M",
			NonconformanceResultantResponseCode = "z",
			Description = "K",
			Quantity = 4,
			UnitOfMeasurementCode = "me",
		};

		var actual = Map.MapObject<NCA_NonconformanceAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
