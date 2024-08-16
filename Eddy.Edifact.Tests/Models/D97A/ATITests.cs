using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ATITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ATI++";

		var expected = new ATI_TourInformation()
		{
			TourDetails = null,
			StopoverInformation = null,
		};

		var actual = Map.MapObject<ATI_TourInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
