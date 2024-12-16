using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paramet.Cheetah2;
using Paramet.Cheetah2.Kruger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKruger
{
    public class KrugerFanSelector
    {
        [STAThread]
        public static List<Fan> SelectKrugerFan()
        {

         
            var hertz = Constants.Hertz.Hertz50;

            var KrugerSelection = new Paramet.Cheetah2.Kruger.SimpleSelection();
            var fans = KrugerSelection.Selection(
            new List<string> { "FDA", "KAT", "BDB" },
            //new KrugerSelectionInformation()
            //{
            //    Volume = airFlow.ValueInCMH,
            //    VolumeUnit = Paramet.Cheetah2.Constants.VolumeUnit.vuM3H,
            //    Pressure = esp.ValueInPa,
            //    PressureUnit = Paramet.Cheetah2.Constants.PressureUnit.puPa,
            //    PressureType = Paramet.Cheetah2.Constants.PressureType.ptStatic,
            //    Conditions = new Conditions()
            //    {
            //        OperatingTemperature = 20,
            //        cTestDensity
            //= 1.2
            //    },
            //    MinimumDuty = 95,
            //    MaximumDuty = 105,
            //    Construction = "SingleFrame",
            //    DriveType = Paramet.Cheetah2.Constants.DriveType.Belt,
            //    Hertz = Constants.Hertz.Hertz60
            //},
            new KrugerSelectionInformation()
            {
                //SKUSpecified = "ADA1000",
                Volume = 10000,
                VolumeUnit = Paramet.Cheetah2.Constants.VolumeUnit.vuM3H,
                Pressure = 300,
                PressureUnit = Paramet.Cheetah2.Constants.PressureUnit.puPa,
                PressureType = Paramet.Cheetah2.Constants.PressureType.ptStatic,
                Conditions = new Conditions() { OperatingTemperature = 20, cTestDensity = 1.2 },
                MinimumDiameter = 0,
                MaximumDiameter = 9999,
                MaximumDuty = 95,
                MinimumDuty = 120,
                MotorVoltage = 400,
                Phase = 3,
                Hertz = hertz,
                Construction = "SingleFrame", //For fans except Plenum
                DriveType = Constants.DriveType.Belt,
                IncludeNonStandard = true,
                ServiceFactor = 0.1, //0.1
                AllowMultipleFans = false,
                PlenumWidth = 0,
                PlenumHeight = 0,
                RedundantFans = 0,
                BackflowCompensation = false,
                MinClass = "I",
                MotorEfficiencyGrade = Constants.MotorEfficiency.IE2
            },
            AppDomain.CurrentDomain.BaseDirectory + @"/kruger.dat");

            return fans;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class KrugerDll_Tests
    {
        [TestMethod]
        public void Run_Test()
        {
            var fans = KrugerFanSelector.SelectKrugerFan();
            Assert.AreNotEqual(0, fans.Count);
        }
    }
}
