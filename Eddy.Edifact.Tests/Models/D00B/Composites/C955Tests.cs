using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C955Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:T:7:n";

		var expected = new C955_AttributeType()
		{
			AttributeTypeDescriptionCode = "i",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "7",
			AttributeTypeDescription = "n",
		};

		var actual = Map.MapComposite<C955_AttributeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
