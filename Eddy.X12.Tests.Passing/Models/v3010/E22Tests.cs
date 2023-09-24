using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E22*l*8*4*4*6*1";

		var expected = new E22_DataElementRelationshipsInASegment()
		{
			MaintenanceOperationCode = "l",
			RelationCode = "8",
			PositionInSegment = 4,
			PositionInSegment2 = 4,
			PositionInSegment3 = 6,
			PositionInSegment4 = 1,
		};

		var actual = Map.MapObject<E22_DataElementRelationshipsInASegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.RelationCode = "8";
		subject.PositionInSegment = 4;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredRelationCode(string relationCode, bool isValidExpected)
	{
		var subject = new E22_DataElementRelationshipsInASegment();
		subject.MaintenanceOperationCode = "l";
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
		subject.MaintenanceOperationCode = "l";
		subject.RelationCode = "8";
		if (positionInSegment > 0)
			subject.PositionInSegment = positionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
