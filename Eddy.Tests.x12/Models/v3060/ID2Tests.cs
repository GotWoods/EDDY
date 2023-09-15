using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*Z*s*07*r*7*L*Qm*B";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "Z",
			CashRegisterItemDescription2 = "s",
			SpaceManagementReferenceCode = "07",
			ReferenceIdentification = "r",
			Name = "7",
			Name2 = "L",
			SpaceManagementReferenceCode2 = "Qm",
			ReferenceIdentification2 = "B",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("07", "r", true)]
	[InlineData("07", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode(string spaceManagementReferenceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode = spaceManagementReferenceCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.SpaceManagementReferenceCode2 = "Qm";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qm", "B", true)]
	[InlineData("Qm", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredSpaceManagementReferenceCode2(string spaceManagementReferenceCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new ID2_ItemImageDetail();
		subject.SpaceManagementReferenceCode2 = spaceManagementReferenceCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.SpaceManagementReferenceCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.SpaceManagementReferenceCode = "07";
			subject.ReferenceIdentification = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
