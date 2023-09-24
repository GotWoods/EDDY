using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*4*1*r*6*5*5*1*7*M";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "4",
			DataElementReferenceNumber = 1,
			DataElementType = "r",
			MinimumLength = 6,
			MaximumLength = 5,
			Description = "5",
			NoteIdentificationNumber = 1,
			DataElementReferenceNumber2 = 7,
			CodeListReference = "M",
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceNumber = 1;
		subject.DataElementType = "r";
		subject.MinimumLength = 6;
		subject.MaximumLength = 5;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 7;
			subject.CodeListReference = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "4";
		subject.DataElementType = "r";
		subject.MinimumLength = 6;
		subject.MaximumLength = 5;
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 7;
			subject.CodeListReference = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDataElementType(string dataElementType, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "4";
		subject.DataElementReferenceNumber = 1;
		subject.MinimumLength = 6;
		subject.MaximumLength = 5;
		subject.DataElementType = dataElementType;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 7;
			subject.CodeListReference = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "4";
		subject.DataElementReferenceNumber = 1;
		subject.DataElementType = "r";
		subject.MaximumLength = 5;
		if (minimumLength > 0)
			subject.MinimumLength = minimumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 7;
			subject.CodeListReference = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "4";
		subject.DataElementReferenceNumber = 1;
		subject.DataElementType = "r";
		subject.MinimumLength = 6;
		if (maximumLength > 0)
			subject.MaximumLength = maximumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 7;
			subject.CodeListReference = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "M", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "M", false)]
	public void Validation_AllAreRequiredDataElementReferenceNumber2(int dataElementReferenceNumber2, string codeListReference, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "4";
		subject.DataElementReferenceNumber = 1;
		subject.DataElementType = "r";
		subject.MinimumLength = 6;
		subject.MaximumLength = 5;
		if (dataElementReferenceNumber2 > 0)
			subject.DataElementReferenceNumber2 = dataElementReferenceNumber2;
		subject.CodeListReference = codeListReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
