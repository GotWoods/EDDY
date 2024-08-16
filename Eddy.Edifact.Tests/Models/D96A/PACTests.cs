using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAC+x++++";

		var expected = new PAC_Package()
		{
			NumberOfPackages = "x",
			PackagingDetails = null,
			PackageType = null,
			PackageTypeIdentification = null,
			ReturnablePackageDetails = null,
		};

		var actual = Map.MapObject<PAC_Package>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
