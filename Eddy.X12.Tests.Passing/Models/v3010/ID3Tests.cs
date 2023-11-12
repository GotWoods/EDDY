using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*BQREfqPRDEYL*yC*c*3*7*6*6*1*we*8*lS*9*Xw*7*1*9*8*NO*k*7*yr";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "BQREfqPRDEYL",
			ProductServiceIDQualifier = "yC",
			ProductServiceID = "c",
			Pack = 3,
			InnerPack = 7,
			Height = 6,
			Width = 6,
			ItemDepth = 1,
			UnitOfMeasurementCode = "we",
			Weight = 8,
			UnitOfMeasurementCode2 = "lS",
			Volume = 9,
			UnitOfMeasurementCode3 = "Xw",
			TrayCount = 7,
			Height2 = 1,
			Width2 = 9,
			ItemDepth2 = 8,
			UnitOfMeasurementCode4 = "NO",
			NestingCode = "k",
			Nesting = 7,
			UnitOfMeasurementCode5 = "yr",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
