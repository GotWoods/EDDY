using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*2*r*n*3*9*l*4*U*d";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "2",
			DataElementReferenceCode = "r",
			DataElementDataTypeCode = "n",
			MinimumLength = 3,
			MaximumLength = 9,
			Description = "l",
			NoteIdentificationNumber = 4,
			DataElementReferenceCode2 = "U",
			CodeListReference = "d",
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceCode = "r";
		subject.DataElementDataTypeCode = "n";
		subject.MinimumLength = 3;
		subject.MaximumLength = 9;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "2";
		subject.DataElementDataTypeCode = "n";
		subject.MinimumLength = 3;
		subject.MaximumLength = 9;
		subject.DataElementReferenceCode = dataElementReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredDataElementDataTypeCode(string dataElementDataTypeCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "2";
		subject.DataElementReferenceCode = "r";
		subject.MinimumLength = 3;
		subject.MaximumLength = 9;
		subject.DataElementDataTypeCode = dataElementDataTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "2";
		subject.DataElementReferenceCode = "r";
		subject.DataElementDataTypeCode = "n";
		subject.MaximumLength = 9;
		if (minimumLength > 0)
		subject.MinimumLength = minimumLength;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "2";
		subject.DataElementReferenceCode = "r";
		subject.DataElementDataTypeCode = "n";
		subject.MinimumLength = 3;
		if (maximumLength > 0)
		subject.MaximumLength = maximumLength;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("U", "d", true)]
	[InlineData("", "d", false)]
	[InlineData("U", "", false)]
	public void Validation_AllAreRequiredDataElementReferenceCode2(string dataElementReferenceCode2, string codeListReference, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "2";
		subject.DataElementReferenceCode = "r";
		subject.DataElementDataTypeCode = "n";
		subject.MinimumLength = 3;
		subject.MaximumLength = 9;
		subject.DataElementReferenceCode2 = dataElementReferenceCode2;
		subject.CodeListReference = codeListReference;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
