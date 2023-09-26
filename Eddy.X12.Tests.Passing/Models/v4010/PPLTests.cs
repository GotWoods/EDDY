using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPL*5v*psDdSArJ*IZfkijMr*V*L";

		var expected = new PPL_PriceSupportData()
		{
			AcquisitionDataCode = "5v",
			Date = "psDdSArJ",
			Date2 = "IZfkijMr",
			Description = "V",
			ProposalDataDetailIdentifierCode = "L",
		};

		var actual = Map.MapObject<PPL_PriceSupportData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
