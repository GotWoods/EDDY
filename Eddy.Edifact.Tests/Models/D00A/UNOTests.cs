using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNO+K+++++++V";

		var expected = new UNO_ObjectHeader()
		{
			PackageReferenceNumber = "K",
			ReferenceIdentification = null,
			ObjectTypeIdentification = null,
			StatusOfTheObject = null,
			DialogueReference = null,
			StatusOfTransferInteractive = null,
			DateAndOrTimeOfInitiation = null,
			TestIndicator = "V",
		};

		var actual = Map.MapObject<UNO_ObjectHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredPackageReferenceNumber(string packageReferenceNumber, bool isValidExpected)
	{
		var subject = new UNO_ObjectHeader();
		//Required fields
		subject.ReferenceIdentification = new S020_ReferenceIdentification();
		subject.ObjectTypeIdentification = new S021_ObjectTypeIdentification();
		subject.StatusOfTheObject = new S022_StatusOfTheObject();
		//Test Parameters
		subject.PackageReferenceNumber = packageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new UNO_ObjectHeader();
		//Required fields
		subject.PackageReferenceNumber = "K";
		subject.ObjectTypeIdentification = new S021_ObjectTypeIdentification();
		subject.StatusOfTheObject = new S022_StatusOfTheObject();
		//Test Parameters
		if (referenceIdentification != "") 
			subject.ReferenceIdentification = new S020_ReferenceIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredObjectTypeIdentification(string objectTypeIdentification, bool isValidExpected)
	{
		var subject = new UNO_ObjectHeader();
		//Required fields
		subject.PackageReferenceNumber = "K";
		subject.ReferenceIdentification = new S020_ReferenceIdentification();
		subject.StatusOfTheObject = new S022_StatusOfTheObject();
		//Test Parameters
		if (objectTypeIdentification != "") 
			subject.ObjectTypeIdentification = new S021_ObjectTypeIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredStatusOfTheObject(string statusOfTheObject, bool isValidExpected)
	{
		var subject = new UNO_ObjectHeader();
		//Required fields
		subject.PackageReferenceNumber = "K";
		subject.ReferenceIdentification = new S020_ReferenceIdentification();
		subject.ObjectTypeIdentification = new S021_ObjectTypeIdentification();
		//Test Parameters
		if (statusOfTheObject != "") 
			subject.StatusOfTheObject = new S022_StatusOfTheObject();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
