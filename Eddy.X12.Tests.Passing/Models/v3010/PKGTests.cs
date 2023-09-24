using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*f*P*FG*C*j";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionType = "f",
			PackagingCharacteristicCode = "P",
			AssociationQualifierCode = "FG",
			PackagingDescriptionCode = "C",
			Description = "j",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
