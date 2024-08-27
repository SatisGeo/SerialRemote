using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms.VisualStyles;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;
using static SerialRemote.PMG2Serial;
using static System.Windows.Forms.DataFormats;

namespace SerialRemote
{
    /// <summary>
    /// Class <c>PMG2Serial</c> PMG2Serial is a class that remotely controls
    /// the PMG-2 proton magnetometer and gradiometer measurement 
    /// using a USB serial port. 
    /// </summary>
    internal class PMG2Serial
    {
        /// <summary>
        /// Serial port class.
        /// </summary>
        private static SerialPort _serialPort;
        /// <summary>
        /// PMG2 Sensor mode. Single or gradient.
        /// </summary>
        public enum SensorMode { Single = 'S', Gradient = 'G'};
        /// <summary>
        /// PMG2 Tune mode. Auto or manual.
        /// </summary>
        public enum TuneMode { Auto = 'A', Manual = 'M' };
        /// <summary>
        /// This struct contains settings for the instrument tune options.
        /// </summary>
        public struct Tune
        {
            public TuneMode Mode;      // Automatic or manual tune
            public int      UpField;   // Up sensor tune in nT
            public int      DownField; // Down sensor tune in nT. This parameter is used for gradient and for ingle should have the value of the UpField.
        };
        /// <summary>
        /// This struct contains the measurement results.
        /// </summary>
        public struct MeasuredData
        {
            /// <summary>
            /// Status of the measurement
            /// </summary>
            public int Status;
            /// <summary>
            /// Timestamp of the measurement.
            /// </summary>
            public DateTime TimeStamp;
            /// <summary>
            /// In single mode the field in nT, in gradient mode gradient in nT.
            /// </summary>
            public double Field;
            /// <summary>
            /// In single mode zero, in gradient mode down sensor field in nT.
            /// </summary>
            public double DownField;
            /// <summary>
            /// Error of the measurement in nT
            /// </summary>
            public double Error;
            /// <summary>
            /// Signal amplitude
            /// </summary>
            public int Amplitude;
            /// <summary>
            /// Signal decay
            /// </summary>
            public double Decay;
        };
        /// <summary>
        /// Tune status constants
        /// </summary>
        public const int TuneUpCanNotTune = 1;
        public const int TuneDownCanNotTune = 2;
        public const int TuneUpTuneChanged = 4;
        public const int TuneDownTuneChanged = 8;
        /// <summary>
        /// Sensor status constants
        /// </summary>
        public const int SensorCheckUp = 1;
        public const int SensorCheckDown = 2;
        public const int SensorCheckBooth = 3;
        public const int SensorLowVoltage = 4;
        /// <summary>
        /// <c>PMG2Serial</c> constrotor. Initiaise serial port parameters.
        /// </summary>
        public PMG2Serial()
        {
            _serialPort = new SerialPort();

            //_serialPort.PortName = SetPortName(_serialPort.PortName);
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 2000;
            _serialPort.WriteTimeout = 500;
        }
        /// <summary>
        /// Open communication with the PMG-2
        /// </summary>
        /// <param name="portname">Name of the serial port (com1 to comXX)</param>
        public void Open(string portname)
        {
            if (_serialPort.IsOpen)
                return;

            _serialPort.PortName = portname;
            _serialPort.Open();
        }
        /// <summary>
        /// Close the communication with the PMG-2.
        /// </summary>
        public void Close()
        {
            _serialPort.Close();
        }
        /// <summary>
        /// Starts the PMG-2 measurement.
        /// </summary>
        /// <returns>MeasuredData struct with measurement status and measured values.</returns>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// "RUN\n"
        /// The response for single mode is:
        /// "p0,p1,p2,0,p3,p4,p5\n"
        /// p0 - is an integer and holds the status of the measurement.
        /// p1 - is an integer and holds a POSIX timestamp.
        /// p2 - is decimal and holds the value of the measured field in nT.
        /// p3 - is decimal and holds an error of the measured field in nT.
        /// p4 - is an integer and holds measured signal amplitude.
        /// p5 - is decimal land holds signal decay time in seconds.
        ///
        /// The response for gradient mode is:
        /// "p0,p1,p2,p3,p4,p5,p6\n"
        /// p0 - is an integer and holds the status of the measurement.
        /// p1 - is an integer and holds a POSIX timestamp.
        /// p2 - is decimal and holds the value of the measured field gradient in nT.
        /// p3 -  is decimal and holds the value of the measured field in nT of the down sensor.
        /// p4 - is decimal and holds the worst error of the booth field measured in nT.
        /// p5 - is an integer that holds the worst signal amplitude of the booth field measured.
        /// p6 - is the decimal that holds the worst signal decay of the booth field measured.
        /// </remarks>
        /// 
        public MeasuredData Measure()
        {
            String response;
            MeasuredData measuredData = new MeasuredData();
            _serialPort.WriteLine(String.Format("RUN"));

            response = _serialPort.ReadLine();

            String[] tokens = response.Split(',');

            if (tokens.Length == 7)
            {
                measuredData.Status = System.Convert.ToInt32(tokens[0]);
                measuredData.TimeStamp =
                    DateTimeOffset.FromUnixTimeSeconds(System.Convert.ToInt64(tokens[1])).DateTime;
                measuredData.Field = System.Convert.ToDouble(tokens[2]);
                measuredData.DownField = System.Convert.ToDouble(tokens[3]);
                measuredData.Error = System.Convert.ToDouble(tokens[4]);
                measuredData.Amplitude = System.Convert.ToInt32(tokens[5]);
                measuredData.Decay = System.Convert.ToDouble(tokens[6]);
            }
            else
            {
                throw new Exception("RUN Command read error");
            }

            return measuredData;
        }
        /// <summary>
        /// Set sensor mode to single or gradient.
        /// </summary>
        /// <param name="mode">Selected mode.</param>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// The command to set measurement mode is: 
        /// "MOD,p0\n"
        /// p0 - is a char. S - to set single mode and G - to set gradient mode.
        /// If everything is all right, the response is:
        /// "OK\n" otherwise (wrong command format) "ERROR\n"
        /// </remarks>
        /// 
        public void SetMode(SensorMode mode)
        {
            String response;
            if(mode == SensorMode.Single)
                _serialPort.WriteLine(String.Format("MOD,S"));
            else
                _serialPort.WriteLine(String.Format("MOD,G"));

            response = _serialPort.ReadLine();
            if (response.Contains("ERROR"))
                throw new Exception("MOD Command wrong paramter!");
        }
        /// <summary>
        /// Set tune parameters.
        /// </summary>
        /// <param name="tune">Tune struct with tune settings.</param>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// The command to set the tune is: 
        /// "TUN,p0,p1,p2\n"
        /// p0 - is a char. A - for the automatic tune and M - for the manual tune.
        /// p1 -  is an integer that holds the field's approximate value in nT for 
        /// the up sensor in the range 20 000 to 99 990 nT.
        /// p2 - is an integer that holds the field's approximate value in nT 
        /// for the down sensor in the range 20 000 to 99 990 nT. For the single mode,
        /// this value should match the p1 value.
        /// If everything is all right, the response is:
        /// "OK\n" otherwise (wrong command format) "ERROR\n"
        /// </remarks>
        public void SetTune(Tune tune)
        {
            String response;
            if (tune.Mode == TuneMode.Auto)
            {
                _serialPort.WriteLine(
                String.Format("TUN,A,{0},{1}", tune.UpField, tune.DownField));
            }
            else
            {
                _serialPort.WriteLine(
                String.Format("TUN,M,{0},{1}", tune.UpField, tune.DownField));
            }
            response = _serialPort.ReadLine();
            if (response.Contains("ERROR"))
                throw new Exception("TUN Command wrong paramter!");
        }
        /// <summary>
        /// Get the PMG-2 mode settings.
        /// </summary>
        /// <returns>Mode settings.</returns>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// The command to get measurement mode is: 
        /// "MOD\n"
        /// If everything is all right, the response is:
        /// "p0\n"
        /// p0 - is a char. S - indicating single mode and G - indicating gradient mode.
        /// Otherwise(wrong command format) "ERROR\n"
        /// </remarks>
        public SensorMode GetMode()
        {
            String response;
            SensorMode mode;
            _serialPort.WriteLine(String.Format("MOD"));
            response = _serialPort.ReadLine();
            if (response[0] == 'S')
                mode = SensorMode.Single;
            else if (response[0] == 'G')
                mode = SensorMode.Gradient;
            else
                throw new Exception("MOD wrong response!");
            return mode;
        }
        /// <summary>
        /// Get the PMG-2 tune setting.
        /// </summary>
        /// <returns>Returns Tune struct containing current tune parameters.</returns>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// The command to get the tune is: 
        /// "TUN\n"
        /// If everything is all right, the response is:
        /// "p0,p1,p3\n"
        /// p0 - is a char. A - for the automatic tune and M - for the manual tune.
        /// p1 -  is an integer that holds the current field's approximate value in nT
        /// for the up sensor in the range 20 000 to 99 990 nT.
        /// p2 - is an integer that holds the current field's approximate value in nT
        /// for the down sensor in the range 20 000 to 99 990 nT. For the single mode,
        /// this value has no meaning.
        /// Otherwise(wrong command format) "ERROR\n"
        /// </remarks>
        public Tune GetTune()
        {
            String response;
            Tune tune = new Tune();
            _serialPort.WriteLine(String.Format("TUN"));
            response = _serialPort.ReadLine();
            String[] tokens = response.Split(',');

            if(tokens.Length == 3)
            {
                if (tokens[0] == "A")
                    tune.Mode = TuneMode.Auto;
                else
                    tune.Mode = TuneMode.Manual;

                tune.UpField = System.Convert.ToInt32(tokens[1]);
                tune.DownField = System.Convert.ToInt32(tokens[2]);
            }
            else
            {
                throw new Exception("TUN wrong response!");
            }

            return tune;
        }
    }
}
