using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSD+L+s++w+v+++";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCoded = "L",
			SampleSelectionMethodCoded = "s",
			FrequencyDetails = null,
			SampleDescriptionCoded = "w",
			SampleDirectionCoded = "v",
			SampleLocationDetails = null,
			SampleLocationDetails2 = null,
			SampleLocationDetails3 = null,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
