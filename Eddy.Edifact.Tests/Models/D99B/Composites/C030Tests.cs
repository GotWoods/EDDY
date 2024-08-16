using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:w:m:w";

		var expected = new C030_EventType()
		{
			EventTypeDescriptionCode = "8",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "m",
			EventTypeDescription = "w",
		};

		var actual = Map.MapComposite<C030_EventType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
