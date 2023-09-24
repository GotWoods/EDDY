using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*b*5*2*G*r*3*9";

		var expected = new E24_DataElementSequenceInASegmentOrComposite()
		{
			MaintenanceOperationCode = "b",
			PositionInSegmentOrComposite = 5,
			DataElementReferenceNumber = 2,
			RequirementDesignator = "G",
			DataElementType = "r",
			NoteIdentificationNumber = 3,
			Count = 9,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.PositionInSegmentOrComposite = 5;
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = "G";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "b";
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = "G";
		if (positionInSegmentOrComposite > 0)
			subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "b";
		subject.PositionInSegmentOrComposite = 5;
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
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "b";
		subject.PositionInSegmentOrComposite = 5;
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
