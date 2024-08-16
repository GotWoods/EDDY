using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:X:S:E";

		var expected = new C030_EventType()
		{
			EventTypeDescriptionCode = "D",
			CodeListIdentificationCode = "X",
			CodeListResponsibleAgencyCode = "S",
			EventTypeDescription = "E",
		};

		var actual = Map.MapComposite<C030_EventType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
