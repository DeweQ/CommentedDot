using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentedDotApi.Library.Models
{
    public class DotModel
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Radius { get; set; }
        public string HEXColor { get; set; }
        public List<CommentModel> Comments { get; set; } = new();

    }
}