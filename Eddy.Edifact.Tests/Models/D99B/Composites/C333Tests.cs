using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C333Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:p:D:z";

		var expected = new C333_InformationRequest()
		{
			RequestedInformationDescriptionCode = "O",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "D",
			RequestedInformationDescription = "z",
		};

		var actual = Map.MapComposite<C333_InformationRequest>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
