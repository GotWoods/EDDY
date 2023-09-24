using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SHPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHP*31*4*Gmg*ZblS3T*vWpl*I3Z41X*6SnU";

		var expected = new SHP_ShippedReceivedInformation()
		{
			QuantityQualifier = "31",
			Quantity = 4,
			DateTimeQualifier = "Gmg",
			Date = "ZblS3T",
			Time = "vWpl",
			Date2 = "I3Z41X",
			Time2 = "6SnU",
		};

		var actual = Map.MapObject<SHP_ShippedReceivedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
