using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSD+s+O++V+4+++";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStepCoded = "s",
			SampleSelectionMethodCoded = "O",
			FrequencyDetails = null,
			SampleDescriptionCoded = "V",
			SampleDirectionCoded = "4",
			SampleLocationDetails = null,
			SampleLocationDetails2 = null,
			SampleLocationDetails3 = null,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
