using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*s*1*4*v*6*6*2";

		var expected = new E24_DataElementSequenceInASegmentOrComposite()
		{
			MaintenanceOperationCode = "s",
			PositionInSegmentOrComposite = 1,
			DataElementReferenceNumber = 4,
			RequirementDesignator = "v",
			DataElementUsageType = "6",
			NoteIdentificationNumber = 6,
			Count = 2,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceNumber = 4;
		subject.RequirementDesignator = "v";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "s";
		subject.DataElementReferenceNumber = 4;
		subject.RequirementDesignator = "v";
		if (positionInSegmentOrComposite > 0)
			subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "s";
		subject.PositionInSegmentOrComposite = 1;
		subject.RequirementDesignator = "v";
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "s";
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceNumber = 4;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
