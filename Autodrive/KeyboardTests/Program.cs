﻿
using Autodrive;
using Autodrive._1DScanners.StandardImaging;
using Autodrive.Electrometers.StandardImaging;
using Autodrive.Jobs.Output;
using Autodrive.Linacs;
using Autodrive.Linacs.Varian.CSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var dv = new DoseView1D();
            dv.Initalize("COM12");

            var max = new Max4000();
            max.Initialize("COM9");
            max.Verify();

            //  max.Zero().Wait();

            var bias = max.SetBias(Autodrive.Electrometers.Bias.NEG_100PERC);
            max.SetMode(Autodrive.Electrometers.MeasureMode.CHARGE);

            var linac = new CSeriesLinac();
            linac.Initialize("COM10");

            var ofTest = OutputFactors.GetDefault(linac, max, dv);
            ofTest.Run(false, true);

            // var session = ServiceModeSession.Instance;
            // session.Keyboard = new VetraKeyboard("COM3");
            // session.KeySpeedMs = 100;
            //// session.EnterDefaultPassword();
            // session.ResetConsoleState();
            // //session.ToggleDefaultInterlocks();


            // session.MachineState.GantryRot = 180;
            // session.MachineState.CollimatorRot = 180;
            // session.MachineState.X1 = 5.0;
            // session.MachineState.X2 = 5.0;
            // session.MachineState.Y1 = 5.0;
            // session.MachineState.Y2 = 5.0;
            // session.MachineState.CouchLat = 100.2;
            // session.MachineState.CouchVert = 127.9;
            // session.MachineState.CouchLng = 54.4;

            //MonthlyMechanicals.InitializePosition();
            //MonthlyMechanicals.CouchStarShot();
            Console.Read();
            //  var tasks = new List<ITask>();
        }

        private static void Logger_Logged(string toLog)
        {
            Console.WriteLine(toLog);
        }
    }
}
