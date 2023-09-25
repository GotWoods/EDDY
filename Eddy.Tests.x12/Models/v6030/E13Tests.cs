using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E13*m*2*D*Hq*k*8*1h*7*2*1";

		var expected = new E13_SegmentOrderInTransactionSet()
		{
			MaintenanceOperationCode = "m",
			PositionInSet = 2,
			SectionDesignatorCode = "D",
			SegmentIDCode = "Hq",
			RequirementDesignatorCode = "k",
			MaximumUse = 8,
			LoopName = "1h",
			LoopRepeatCount = 7,
			LoopLevelNumber = 2,
			NoteIdentificationNumber = 1,
		};

		var actual = Map.MapObject<E13_SegmentOrderInTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		//Required fields
		subject.PositionInSet = 2;
		//Test Parameters
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredPositionInSet(int positionInSet, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		//Required fields
		subject.MaintenanceOperationCode = "m";
		//Test Parameters
		if (positionInSet > 0) 
			subject.PositionInSet = positionInSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
