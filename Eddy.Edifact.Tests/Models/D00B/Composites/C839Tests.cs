using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C839Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:0:F:w";

		var expected = new C839_AttendeeCategory()
		{
			AttendeeCategoryDescriptionCode = "x",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "F",
			AttendeeCategoryDescription = "w",
		};

		var actual = Map.MapComposite<C839_AttendeeCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
