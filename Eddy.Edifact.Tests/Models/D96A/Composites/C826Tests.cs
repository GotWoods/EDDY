using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C826Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:s:J:H";

		var expected = new C826_Action()
		{
			ActionRequestNotificationCoded = "2",
			CodeListQualifier = "s",
			CodeListResponsibleAgencyCoded = "J",
			ActionRequestNotification = "H",
		};

		var actual = Map.MapComposite<C826_Action>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
