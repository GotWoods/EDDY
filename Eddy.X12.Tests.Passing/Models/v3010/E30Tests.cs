using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*r*3*b*5*1*0*7";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "r",
			DataElementReferenceNumber = 3,
			DataElementType = "b",
			MinimumLength = 5,
			MaximumLength = 1,
			Description = "0",
			NoteIdentificationNumber = 7,
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceNumber = 3;
		subject.DataElementType = "b";
		subject.MinimumLength = 5;
		subject.MaximumLength = 1;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "r";
		subject.DataElementType = "b";
		subject.MinimumLength = 5;
		subject.MaximumLength = 1;
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredDataElementType(string dataElementType, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "r";
		subject.DataElementReferenceNumber = 3;
		subject.MinimumLength = 5;
		subject.MaximumLength = 1;
		subject.DataElementType = dataElementType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "r";
		subject.DataElementReferenceNumber = 3;
		subject.DataElementType = "b";
		subject.MaximumLength = 1;
		if (minimumLength > 0)
			subject.MinimumLength = minimumLength;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "r";
		subject.DataElementReferenceNumber = 3;
		subject.DataElementType = "b";
		subject.MinimumLength = 5;
		if (maximumLength > 0)
			subject.MaximumLength = maximumLength;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
