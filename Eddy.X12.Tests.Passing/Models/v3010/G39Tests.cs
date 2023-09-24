using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*C3osVNPuuTNL*D2*3*kM*5*0*T*7*Sa*3*iw*6*Wr*2*do*992875*4*7*pm*o*Z1*9*XU*D";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "C3osVNPuuTNL",
			ProductServiceIDQualifier = "D2",
			ProductServiceID = "3",
			SpecialHandlingCode = "kM",
			UnitWeight = 5,
			WeightQualifier = "0",
			WeightUnitQualifier = "T",
			Height = 7,
			UnitOfMeasurementCode = "Sa",
			Width = 3,
			UnitOfMeasurementCode2 = "iw",
			Length = 6,
			UnitOfMeasurementCode3 = "Wr",
			Volume = 2,
			UnitOfMeasurementCode4 = "do",
			PalletBlockAndTiers = 992875,
			Pack = 4,
			Size = 7,
			UnitOfMeasurementCode5 = "pm",
			Color = "o",
			ShipmentIdentification = "Z1",
			AlternateTiersPerPallet = "9",
			ProductServiceIDQualifier2 = "XU",
			ProductServiceID2 = "D",
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
