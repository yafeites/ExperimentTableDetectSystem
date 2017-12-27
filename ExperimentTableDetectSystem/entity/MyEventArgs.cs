using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.entity
{
    public class MyEventArgs : EventArgs
    {
        public int Temp { get; set; }
        public object obj { get; set; }
    }
}
