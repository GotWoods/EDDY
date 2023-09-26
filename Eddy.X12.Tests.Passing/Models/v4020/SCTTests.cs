using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCT*X*2*I*M3*6*N";

		var expected = new SCT_SchoolType()
		{
			AcademicCreditTypeCode = "X",
			Quantity = 2,
			SessionCode = "I",
			DateTimePeriodFormatQualifier = "M3",
			DateTimePeriod = "6",
			YesNoConditionOrResponseCode = "N",
		};

		var actual = Map.MapObject<SCT_SchoolType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
