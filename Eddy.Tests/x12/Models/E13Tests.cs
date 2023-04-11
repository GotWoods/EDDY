using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E13*M*7*i*zN*S*9*Ty*9*7*1";

		var expected = new E13_SegmentOrderInTransactionSet()
		{
			MaintenanceOperationCode = "M",
			PositionInSet = 7,
			SectionDesignatorCode = "i",
			SegmentIDCode = "zN",
			RequirementDesignatorCode = "S",
			MaximumUse = 9,
			LoopName = "Ty",
			LoopRepeatCount = 9,
			LoopLevelNumber = 7,
			NoteIdentificationNumber = 1,
		};

		var actual = Map.MapObject<E13_SegmentOrderInTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		subject.PositionInSet = 7;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPositionInSet(int positionInSet, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		subject.MaintenanceOperationCode = "M";
		if (positionInSet > 0)
		subject.PositionInSet = positionInSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
