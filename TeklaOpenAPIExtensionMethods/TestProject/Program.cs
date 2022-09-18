using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklaOpenAPIExtension;
using tsd = Tekla.Structures.Drawing;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var dh = new tsd.DrawingHandler();
            var drawing = dh.GetActiveDrawing();

            var selector = dh.GetDrawingObjectSelector();
            var selected = selector.GetSelected().ToList<tsd.View>().FirstOrDefault();

            var parts = selected.GetModelParts();
        }
    }
}
