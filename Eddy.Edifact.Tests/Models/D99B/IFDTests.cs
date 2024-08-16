using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class IFDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IFD+y++++a";

		var expected = new IFD_InformationDetail()
		{
			InformationDetailsCodeQualifier = "y",
			InformationCategory = null,
			InformationType = null,
			InformationDetail = null,
			StatusDescriptionCode = "a",
		};

		var actual = Map.MapObject<IFD_InformationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
