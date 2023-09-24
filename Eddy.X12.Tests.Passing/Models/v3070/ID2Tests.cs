using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*m*H*XW*b*4*Z*kj*j";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "m",
			CashRegisterItemDescription2 = "H",
			SpaceManagementReferenceCode = "XW",
			ReferenceIdentification = "b",
			Name = "4",
			Name2 = "Z",
			SpaceManagementReferenceCode2 = "kj",
			ReferenceIdentification2 = "j",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XW", "b", true)]
	[InlineData("XW", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.SpaceManagementReferenceCode2 = "kj";
			subject.ReferenceIdentification2 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kj", "j", true)]
	[InlineData("kj", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.SpaceManagementReferenceCode = "XW";
			subject.ReferenceIdentification = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
