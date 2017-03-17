using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtRaces
{
    class Greyhound
    {
        public PictureBox greyhoundPicBox = new PictureBox();
        public int trackLength;
        public int dogSpeed;
        public bool reachTheEnd;
        public Greyhound(int Length, int position)
        {
            greyhoundPicBox.Left = position;
            trackLength = Length;
        }
        public void Run()
        {
            if (greyhoundPicBox.Left < trackLength)
                greyhoundPicBox.Left += 2* dogSpeed;
            else reachTheEnd = true;
        }
    }
}
