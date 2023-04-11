using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Core.EdiFact.Models.Elements
{
    public class C001_TransportMeans : IElement
    {
        [Position(1)]
        public string Transportmeansdescriptioncode { get; set; }

        [Position(2)]
        public string Codelistidentificationcode { get; set; }

        [Position(3)]
        public string Codelistresponsibleagencycode { get; set; }

        [Position(4)]
        public string Transportmeansdescription { get; set; }

        public void Validate()
        {
            var validator = new BasicValidator<C001_TransportMeans>(this);
            validator.Length(x => x.Transportmeansdescriptioncode, 1, 8);
            validator.Length(x => x.Codelistidentificationcode, 1, 17);
            validator.Length(x => x.Codelistresponsibleagencycode, 1, 3);
            validator.Length(x => x.Transportmeansdescription, 1, 17);
        }
    }
}
