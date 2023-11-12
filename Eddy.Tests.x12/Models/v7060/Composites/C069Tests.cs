using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C069Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "bp*GB*y4*l9*3A*ZU*el*WT*K1*Gd*RI*k9*lP*ZS*Fy";

		var expected = new C069_CompositeStateOrProvinceCode()
		{
			StateOrProvinceCode = "bp",
			StateOrProvinceCode2 = "GB",
			StateOrProvinceCode3 = "y4",
			StateOrProvinceCode4 = "l9",
			StateOrProvinceCode5 = "3A",
			StateOrProvinceCode6 = "ZU",
			StateOrProvinceCode7 = "el",
			StateOrProvinceCode8 = "WT",
			StateOrProvinceCode9 = "K1",
			StateOrProvinceCode10 = "Gd",
			StateOrProvinceCode11 = "RI",
			StateOrProvinceCode12 = "k9",
			StateOrProvinceCode13 = "lP",
			StateOrProvinceCode14 = "ZS",
			StateOrProvinceCode15 = "Fy",
		};

		var actual = Map.MapObject<C069_CompositeStateOrProvinceCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bp", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new C069_CompositeStateOrProvinceCode();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
