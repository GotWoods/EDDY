using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C553Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:Z:X:a";

		var expected = new C553_RelatedLocationTwoIdentification()
		{
			SecondRelatedLocationIdentifier = "8",
			CodeListIdentificationCode = "Z",
			CodeListResponsibleAgencyCode = "X",
			SecondRelatedLocationName = "a",
		};

		var actual = Map.MapComposite<C553_RelatedLocationTwoIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
