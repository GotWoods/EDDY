using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C841Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:B:V:q";

		var expected = new C841_AttendanceDischargeDetails()
		{
			DischargeTypeDescriptionCode = "H",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "V",
			DischargeTypeDescription = "q",
		};

		var actual = Map.MapComposite<C841_AttendanceDischargeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
