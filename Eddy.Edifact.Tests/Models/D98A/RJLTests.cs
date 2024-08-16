using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class RJLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RJL++";

		var expected = new RJL_AccountingJournalIdentification()
		{
			AccountingJournalIdentification = null,
			AccountingEntryTypeDetails = null,
		};

		var actual = Map.MapObject<RJL_AccountingJournalIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
