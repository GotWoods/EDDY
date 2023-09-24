using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class E22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E22*3*X*7*4*6*4*1*1*5*7*9*4";

		var expected = new E22_DataElementRelationshipsInASegmentOrComposite()
		{
			MaintenanceOperationCode = "3",
			RelationCode = "X",
			PositionInSegmentOrComposite = 7,
			PositionInSegmentOrComposite2 = 4,
			PositionInSegmentOrComposite3 = 6,
			PositionInSegmentOrComposite4 = 4,
			PositionInSegmentOrComposite5 = 1,
			PositionInSegmentOrComposite6 = 1,
			PositionInSegmentOrComposite7 = 5,
			PositionInSegmentOrComposite8 = 7,
			PositionInSegmentOrComposite9 = 9,
			PositionInSegmentOrComposite10 = 4,
		};

		var actual = Map.MapObject<E22_DataElementRelationshipsInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.RelationCode = "X";
		subject.PositionInSegmentOrComposite = 7;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRelationCode(string relationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.MaintenanceOperationCode = "3";
		subject.PositionInSegmentOrComposite = 7;
		subject.RelationCode = relationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.MaintenanceOperationCode = "3";
		subject.RelationCode = "X";
		if (positionInSegmentOrComposite > 0)
			subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
