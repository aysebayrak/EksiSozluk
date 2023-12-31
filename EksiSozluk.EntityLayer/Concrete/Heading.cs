﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.EntityLayer.Concrete
{
    public class Heading
    {
        public int HeadingId { get; set; }
        public string HeadingName { get; set; }
        public DateTime  HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Content> Contents { get; set; }
        public AppUser AppUser { get; set; }
    }
}
