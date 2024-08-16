using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class MOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MOV++f+F";

		var expected = new MOV_CarDeliveryInstruction()
		{
			MovementDetails = null,
			UnitsQuantity = "f",
			LanguageNameCode = "F",
		};

		var actual = Map.MapObject<MOV_CarDeliveryInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
