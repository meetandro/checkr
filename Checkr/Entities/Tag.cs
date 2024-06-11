using System.Collections.Generic;

namespace Checkr.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string TagHex { get; set; }
        public ICollection<Box> Boxes { get; set; }
    }
}
