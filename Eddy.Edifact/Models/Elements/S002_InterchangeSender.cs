using Eddy.Core.Attributes;

namespace Eddy.Edifact.Models.Elements
{
    public class S002_InterchangeSender : IElement
    {
        [Position(1)]
        public string InterchangeSenderIdentification { get; set; }

        [Position(2)]
        public string IdentificationCodeQualifier { get; set; }

        [Position(3)]
        public string InterchangeSenderInternalIdentification { get; set; }

        [Position(4)]
        public string InterchangeSenderInternalSubIdentification { get; set; }
    }
}
