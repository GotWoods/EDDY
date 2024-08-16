using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C839Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:q:7:E";

		var expected = new C839_AttendeeCategory()
		{
			AttendeeCategoryDescriptionCode = "y",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "7",
			AttendeeCategoryDescription = "E",
		};

		var actual = Map.MapComposite<C839_AttendeeCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
