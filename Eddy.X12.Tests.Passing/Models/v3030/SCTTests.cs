using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCT*T*1*Y*Fi*k";

		var expected = new SCT_SchoolType()
		{
			AcademicCreditTypeCode = "T",
			Quantity = 1,
			SessionCode = "Y",
			DateTimePeriodFormatQualifier = "Fi",
			DateTimePeriod = "k",
		};

		var actual = Map.MapObject<SCT_SchoolType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
