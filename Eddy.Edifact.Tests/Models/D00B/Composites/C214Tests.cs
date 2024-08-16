using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C214Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:v:p:p:9";

		var expected = new C214_SpecialServicesIdentification()
		{
			SpecialServiceDescriptionCode = "m",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "p",
			SpecialServiceDescription = "p",
			SpecialServiceDescription2 = "9",
		};

		var actual = Map.MapComposite<C214_SpecialServicesIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
