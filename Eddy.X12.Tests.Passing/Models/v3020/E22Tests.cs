using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E22*L*7*4*3*8*7*8*7*3*1";

		var expected = new E22_DataElementRelationshipsInASegment()
		{
			MaintenanceOperationCode = "L",
			RelationCode = "7",
			PositionInSegment = 4,
			PositionInSegment2 = 3,
			PositionInSegment3 = 8,
			PositionInSegment4 = 7,
			PositionInSegment5 = 8,
			PositionInSegment6 = 7,
			PositionInSegment7 = 3,
			PositionInSegment8 = 1,
		};

		var actual = Map.MapObject<E22_DataElementRelationshipsInASegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.RelationCode = "7";
		subject.PositionInSegment = 4;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredRelationCode(string relationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.MaintenanceOperationCode = "L";
		subject.PositionInSegment = 4;
		subject.RelationCode = relationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredPositionInSegment(int positionInSegment, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.MaintenanceOperationCode = "L";
		subject.RelationCode = "7";
		if (positionInSegment > 0)
			subject.PositionInSegment = positionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
