using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSD+l+w++Z+3+++";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStepCode = "l",
			SampleSelectionMethodCode = "w",
			FrequencyDetails = null,
			SampleStateCode = "Z",
			SampleDirectionCode = "3",
			SampleLocationDetails = null,
			SampleLocationDetails2 = null,
			SampleLocationDetails3 = null,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
