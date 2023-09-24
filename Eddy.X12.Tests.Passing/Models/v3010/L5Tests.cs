using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*1*w*E*Y*OvoYz*4*S";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 1,
			LadingDescription = "w",
			CommodityCode = "E",
			CommodityCodeQualifier = "Y",
			PackagingCode = "OvoYz",
			MarksAndNumbers = "4",
			MarksAndNumbersQualifier = "S",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
