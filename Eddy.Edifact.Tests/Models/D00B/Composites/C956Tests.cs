using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C956Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:T:0:4";

		var expected = new C956_AttributeDetail()
		{
			AttributeDescriptionCode = "Z",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "0",
			AttributeDescription = "4",
		};

		var actual = Map.MapComposite<C956_AttributeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
