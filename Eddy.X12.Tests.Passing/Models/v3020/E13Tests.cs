using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E13*H*3*O*Nh*I*2*LE*4*7*6";

		var expected = new E13_SegmentOrderInTransactionSet()
		{
			MaintenanceOperationCode = "H",
			PositionInSet = 3,
			SectionDesignator = "O",
			SegmentIDCode = "Nh",
			RequirementDesignator = "I",
			MaximumUse = 2,
			LoopName = "LE",
			LoopRepeatCount = 4,
			LoopLevelNumber = 7,
			NoteIdentificationNumber = 6,
		};

		var actual = Map.MapObject<E13_SegmentOrderInTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		//Required fields
		subject.PositionInSet = 3;
		//Test Parameters
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredPositionInSet(int positionInSet, bool isValidExpected)
	{
		var subject = new E13_SegmentOrderInTransactionSet();
		//Required fields
		subject.MaintenanceOperationCode = "H";
		//Test Parameters
		if (positionInSet > 0) 
			subject.PositionInSet = positionInSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
