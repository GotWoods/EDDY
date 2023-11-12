using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSD*rs*9y*3*Iu*AX*kw*Mh";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCode = "rs",
			SampleSelectionMethodCode = "9y",
			SampleFrequencyValuePerUnitOfMeasurementCode = 3,
			UnitOfMeasurementCode = "Iu",
			SampleDescriptionCode = "AX",
			SampleDirectionCode = "kw",
			SampleLocationCode = "Mh",
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
