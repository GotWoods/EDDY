using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C214Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:w:J:H:U";

		var expected = new C214_SpecialServicesIdentification()
		{
			SpecialServiceDescriptionCode = "S",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "J",
			SpecialServiceDescription = "H",
			SpecialServiceDescription2 = "U",
		};

		var actual = Map.MapComposite<C214_SpecialServicesIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
