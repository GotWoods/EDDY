using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C826Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:u:s:0";

		var expected = new C826_Action()
		{
			ActionRequestNotificationDescriptionCode = "n",
			CodeListIdentificationCode = "u",
			CodeListResponsibleAgencyCode = "s",
			ActionRequestNotificationDescription = "0",
		};

		var actual = Map.MapComposite<C826_Action>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
