using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*6*7*Rf*gbU28*0*2*Bl*1*ZU*3*2*9*RA";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 6,
			Size = 7,
			UnitOfMeasurementCode = "Rf",
			PackagingCode = "gbU28",
			WeightQualifier = "0",
			GrossWeightPerPack = 2,
			UnitOfMeasurementCode2 = "Bl",
			GrossVolumePerPack = 1,
			UnitOfMeasurementCode3 = "ZU",
			Length = 3,
			Width = 2,
			Height = 9,
			UnitOfMeasurementCode4 = "RA",
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
