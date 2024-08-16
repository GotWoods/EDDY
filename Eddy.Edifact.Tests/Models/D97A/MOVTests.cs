using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class MOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MOV++X+B";

		var expected = new MOV_CarDeliveryInstruction()
		{
			MovementDetails = null,
			NumberOfUnits = "X",
			LanguageCoded = "B",
		};

		var actual = Map.MapObject<MOV_CarDeliveryInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
