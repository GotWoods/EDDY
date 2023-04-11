using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C070")]
public class C070_CompositeChannelOfDistribution : EdiX12Component
{
    [Position(00)]
    public string ChannelOfDistribution { get; set; }

    [Position(01)]
    public string ChannelOfDistribution2 { get; set; }

    [Position(02)]
    public string ChannelOfDistribution3 { get; set; }

    [Position(03)]
    public string ChannelOfDistribution4 { get; set; }

    [Position(04)]
    public string ChannelOfDistribution5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C070_CompositeChannelOfDistribution>(this);
        validator.Required(x => x.ChannelOfDistribution);
        validator.Length(x => x.ChannelOfDistribution, 2);
        validator.Length(x => x.ChannelOfDistribution2, 2);
        validator.Length(x => x.ChannelOfDistribution3, 2);
        validator.Length(x => x.ChannelOfDistribution4, 2);
        validator.Length(x => x.ChannelOfDistribution5, 2);
        return validator.Results;
    }
}