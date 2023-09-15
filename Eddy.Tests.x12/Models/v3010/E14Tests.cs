using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E14*N*1*Af*9*2*6x*4*5*9";

		var expected = new E14_SegmentOrderInTransactionSet()
		{
			MaintenanceOperationCode = "N",
			PositionInSet = 1,
			SegmentIDCode = "Af",
			RequirementDesignator = "9",
			MaximumUse = 2,
			LoopName = "6x",
			LoopRepeatCount = 4,
			LoopLevelNumber = 5,
			NoteIdentificationNumber = 9,
		};

		var actual = Map.MapObject<E14_SegmentOrderInTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E14_SegmentOrderInTransactionSet();
		subject.PositionInSet = 1;
		subject.SegmentIDCode = "Af";
		subject.RequirementDesignator = "9";
		subject.MaximumUse = 2;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSet(int positionInSet, bool isValidExpected)
	{
		var subject = new E14_SegmentOrderInTransactionSet();
		subject.MaintenanceOperationCode = "N";
		subject.SegmentIDCode = "Af";
		subject.RequirementDesignator = "9";
		subject.MaximumUse = 2;
		if (positionInSet > 0)
			subject.PositionInSet = positionInSet;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Af", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new E14_SegmentOrderInTransactionSet();
		subject.MaintenanceOperationCode = "N";
		subject.PositionInSet = 1;
		subject.RequirementDesignator = "9";
		subject.MaximumUse = 2;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E14_SegmentOrderInTransactionSet();
		subject.MaintenanceOperationCode = "N";
		subject.PositionInSet = 1;
		subject.SegmentIDCode = "Af";
		subject.MaximumUse = 2;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMaximumUse(int maximumUse, bool isValidExpected)
	{
		var subject = new E14_SegmentOrderInTransactionSet();
		subject.MaintenanceOperationCode = "N";
		subject.PositionInSet = 1;
		subject.SegmentIDCode = "Af";
		subject.RequirementDesignator = "9";
		if (maximumUse > 0)
			subject.MaximumUse = maximumUse;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
