using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MEATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MEA*BH*W*8*mG*1*8*sa*aR*zq";

		var expected = new MEA_Measurements()
		{
			MeasurementReferenceIDCode = "BH",
			MeasurementQualifier = "W",
			MeasurementValue = 8,
			UnitOfMeasurementCode = "mG",
			RangeMinimum = 1,
			RangeMaximum = 8,
			MeasurementSignificanceCode = "sa",
			MeasurementAttributeCode = "aR",
			SurfaceLayerPositionCode = "zq",
		};

		var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
