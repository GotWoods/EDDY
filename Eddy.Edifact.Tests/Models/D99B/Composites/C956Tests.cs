using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C956Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "N:y:z:D";

		var expected = new C956_AttributeDetail()
		{
			AttributeDescriptionCode = "N",
			CodeListIdentificationCode = "y",
			CodeListResponsibleAgencyCode = "z",
			AttributeDescription = "D",
		};

		var actual = Map.MapComposite<C956_AttributeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
