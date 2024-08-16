using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class MOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MOV++M+3";

		var expected = new MOV_CarDeliveryInstruction()
		{
			MovementDetails = null,
			NumberOfUnits = "M",
			LanguageNameCode = "3",
		};

		var actual = Map.MapObject<MOV_CarDeliveryInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
