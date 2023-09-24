using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class E22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E22*u*O*2*4*1*7*6*4*6*6*3*6";

		var expected = new E22_DataElementRelationshipsInASegment()
		{
			MaintenanceOperationCode = "u",
			RelationCode = "O",
			PositionInSegment = 2,
			PositionInSegment2 = 4,
			PositionInSegment3 = 1,
			PositionInSegment4 = 7,
			PositionInSegment5 = 6,
			PositionInSegment6 = 4,
			PositionInSegment7 = 6,
			PositionInSegment8 = 6,
			PositionInSegment9 = 3,
			PositionInSegment10 = 6,
		};

		var actual = Map.MapObject<E22_DataElementRelationshipsInASegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.RelationCode = "O";
		subject.PositionInSegment = 2;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredRelationCode(string relationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.MaintenanceOperationCode = "u";
		subject.PositionInSegment = 2;
		subject.RelationCode = relationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredPositionInSegment(int positionInSegment, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.MaintenanceOperationCode = "u";
		subject.RelationCode = "O";
		if (positionInSegment > 0)
			subject.PositionInSegment = positionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
