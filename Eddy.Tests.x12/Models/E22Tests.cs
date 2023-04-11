using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E22*N*7*6*5*7*8*6*8*2*9*8*3";

		var expected = new E22_DataElementRelationshipsInASegmentOrComposite()
		{
			MaintenanceOperationCode = "N",
			RelationCode = "7",
			PositionInSegmentOrComposite = 6,
			PositionInSegmentOrComposite2 = 5,
			PositionInSegmentOrComposite3 = 7,
			PositionInSegmentOrComposite4 = 8,
			PositionInSegmentOrComposite5 = 6,
			PositionInSegmentOrComposite6 = 8,
			PositionInSegmentOrComposite7 = 2,
			PositionInSegmentOrComposite8 = 9,
			PositionInSegmentOrComposite9 = 8,
			PositionInSegmentOrComposite10 = 3,
		};

		var actual = Map.MapObject<E22_DataElementRelationshipsInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.RelationCode = "7";
		subject.PositionInSegmentOrComposite = 6;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredRelationCode(string relationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.MaintenanceOperationCode = "N";
		subject.PositionInSegmentOrComposite = 6;
		subject.RelationCode = relationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegmentOrComposite();
		subject.MaintenanceOperationCode = "N";
		subject.RelationCode = "7";
		if (positionInSegmentOrComposite > 0)
		subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
