using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*k*t*06*u*I*7*6d*F";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "k",
			CashRegisterItemDescription2 = "t",
			SpaceManagementReferenceCode = "06",
			ReferenceIdentification = "u",
			Name = "I",
			Name2 = "7",
			SpaceManagementReferenceCode2 = "6d",
			ReferenceIdentification2 = "F",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("06", "u", true)]
	[InlineData("06", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.SpaceManagementReferenceCode2 = "6d";
			subject.ReferenceIdentification2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6d", "F", true)]
	[InlineData("6d", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.SpaceManagementReferenceCode = "06";
			subject.ReferenceIdentification = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
