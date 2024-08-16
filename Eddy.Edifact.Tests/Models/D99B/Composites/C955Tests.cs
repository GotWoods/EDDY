using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C955Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:h:8:l";

		var expected = new C955_AttributeType()
		{
			AttributeTypeDescriptionCode = "T",
			CodeListIdentificationCode = "h",
			CodeListResponsibleAgencyCode = "8",
			AttributeTypeDescription = "l",
		};

		var actual = Map.MapComposite<C955_AttributeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
