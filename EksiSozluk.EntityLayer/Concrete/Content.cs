using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.EntityLayer.Concrete
{
    public class Content
    {
        public int ContentId{ get; set; }
        public string? ContentTitle { get; set; }
        public DateTime ContentDate { get; set; }
        public bool? ContentStatus { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }


        public AppUser AppUser { get; set; }

    }
}
