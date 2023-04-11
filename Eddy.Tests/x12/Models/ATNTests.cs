using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ATNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATN*3*y3*uB*f*U*e";

		var expected = new ATN_Attendance()
		{
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "y3",
			QuantityQualifier = "uB",
			FrequencyCode = "f",
			AttendanceTypeCode = "U",
			Description = "e",
		};

		var actual = Map.MapObject<ATN_Attendance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new ATN_Attendance();
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
