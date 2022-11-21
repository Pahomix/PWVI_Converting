using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWorkVI
{
    public class Model
    {
        public Model()
        {
            
        }

        public Model(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        public string Name;
        public int Width;
        public int Height;
    }
}
