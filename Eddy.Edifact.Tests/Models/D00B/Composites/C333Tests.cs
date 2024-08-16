using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C333Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:E:8:b";

		var expected = new C333_InformationRequest()
		{
			RequestedInformationDescriptionCode = "t",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "8",
			RequestedInformationDescription = "b",
		};

		var actual = Map.MapComposite<C333_InformationRequest>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
