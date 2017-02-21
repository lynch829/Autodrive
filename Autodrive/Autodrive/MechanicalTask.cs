﻿using Autodrive.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM = Autodrive.ServiceModeSession;
namespace Autodrive
{
    public class MechanicalTask : ITask
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double GantryAngle { get; set; }
        public double CollimatorAngle { get; set; }
        public bool IsModedUp { get; private set; }
        public double CouchVert { get; set; }
        public double CouchLat { get; set; }
        public double CouchLong { get; set; }
        public double CouchRot { get; set; }

        public void ModeUp()
        {
            SM.Instance.SetGantryAutomatic(CollimatorAngle, X1, X2, Y1, Y2, GantryAngle);
            SM.Instance.SetCouchAutomatic(CouchVert, CouchLong, CouchLat, CouchRot);
        }
    }
}
