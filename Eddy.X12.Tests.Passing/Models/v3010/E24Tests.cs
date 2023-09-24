using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*k*1*1*G*G*7";

		var expected = new E24_DataElementSequenceInASegment()
		{
			MaintenanceOperationCode = "k",
			PositionInSegment = 1,
			DataElementReferenceNumber = 1,
			RequirementDesignator = "G",
			DataElementType = "G",
			NoteIdentificationNumber = 7,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegment();
		subject.PositionInSegment = 1;
		subject.DataElementReferenceNumber = 1;
		subject.RequirementDesignator = "G";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSegment(int positionInSegment, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegment();
		subject.MaintenanceOperationCode = "k";
		subject.DataElementReferenceNumber = 1;
		subject.RequirementDesignator = "G";
		if (positionInSegment > 0)
			subject.PositionInSegment = positionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegment();
		subject.MaintenanceOperationCode = "k";
		subject.PositionInSegment = 1;
		subject.RequirementDesignator = "G";
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegment();
		subject.MaintenanceOperationCode = "k";
		subject.PositionInSegment = 1;
		subject.DataElementReferenceNumber = 1;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
