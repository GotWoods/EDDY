using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*m*G*o*8*6*c*2*B*r";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "m",
			DataElementReferenceCode = "G",
			DataElementDataTypeCode = "o",
			MinimumLength = 8,
			MaximumLength = 6,
			Description = "c",
			NoteIdentificationNumber = 2,
			DataElementReferenceCode2 = "B",
			CodeListReference = "r",
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceCode = "G";
		subject.DataElementDataTypeCode = "o";
		subject.MinimumLength = 8;
		subject.MaximumLength = 6;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceCode2 = "B";
			subject.CodeListReference = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "m";
		subject.DataElementDataTypeCode = "o";
		subject.MinimumLength = 8;
		subject.MaximumLength = 6;
		subject.DataElementReferenceCode = dataElementReferenceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceCode2 = "B";
			subject.CodeListReference = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredDataElementDataTypeCode(string dataElementDataTypeCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "m";
		subject.DataElementReferenceCode = "G";
		subject.MinimumLength = 8;
		subject.MaximumLength = 6;
		subject.DataElementDataTypeCode = dataElementDataTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceCode2 = "B";
			subject.CodeListReference = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "m";
		subject.DataElementReferenceCode = "G";
		subject.DataElementDataTypeCode = "o";
		subject.MaximumLength = 6;
		if (minimumLength > 0)
			subject.MinimumLength = minimumLength;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceCode2 = "B";
			subject.CodeListReference = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "m";
		subject.DataElementReferenceCode = "G";
		subject.DataElementDataTypeCode = "o";
		subject.MinimumLength = 8;
		if (maximumLength > 0)
			subject.MaximumLength = maximumLength;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.DataElementReferenceCode2) || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceCode2 = "B";
			subject.CodeListReference = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "r", true)]
	[InlineData("B", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDataElementReferenceCode2(string dataElementReferenceCode2, string codeListReference, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "m";
		subject.DataElementReferenceCode = "G";
		subject.DataElementDataTypeCode = "o";
		subject.MinimumLength = 8;
		subject.MaximumLength = 6;
		subject.DataElementReferenceCode2 = dataElementReferenceCode2;
		subject.CodeListReference = codeListReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
