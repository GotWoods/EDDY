using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C826Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "J:3:G:p";

		var expected = new C826_Action()
		{
			ActionRequestNotificationDescriptionCode = "J",
			CodeListIdentificationCode = "3",
			CodeListResponsibleAgencyCode = "G",
			ActionRequestNotificationDescription = "p",
		};

		var actual = Map.MapComposite<C826_Action>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
