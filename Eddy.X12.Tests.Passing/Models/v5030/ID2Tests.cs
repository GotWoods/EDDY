using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*F*W*mv*Z*b*F*Ym*f";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "F",
			CashRegisterItemDescription2 = "W",
			SpaceManagementReferenceCode = "mv",
			ReferenceIdentification = "Z",
			Name = "b",
			Name2 = "F",
			SpaceManagementReferenceCode2 = "Ym",
			ReferenceIdentification2 = "f",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mv", "Z", true)]
	[InlineData("mv", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.SpaceManagementReferenceCode2 = "Ym";
			subject.ReferenceIdentification2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ym", "f", true)]
	[InlineData("Ym", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.SpaceManagementReferenceCode = "mv";
			subject.ReferenceIdentification = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
