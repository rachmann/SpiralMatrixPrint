using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrameApp.Models
{
    public class SpiralModel
    {
        public int Id { get; set; }
        public String result { get; set; }

        public Boolean ordered { get; set; }
        public List<List<string>> arr { get; set; }


    }
}