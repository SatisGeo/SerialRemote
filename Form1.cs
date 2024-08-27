using static SerialRemote.PMG2Serial;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SerialRemote
{
    public partial class Form1 : Form
    {
        bool portOpen = false;
        bool autoTune = false;
        private PMG2Serial pmgSerial;
        public Form1()
        {
            InitializeComponent();
            pmgSerial = new PMG2Serial();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void b_open_close_Click(object sender, EventArgs e)
        {
            try
            {
                if (portOpen == false)
                {
                    pmgSerial.Open(String.Format("COM{0}", n_serialport.Value));
                    b_open_close.Text = "Close";
                    portOpen = true;
                    b_set.Enabled = true;
                    b_measure.Enabled = true;

                    SensorMode curmode = pmgSerial.GetMode();
                    Tune tune = pmgSerial.GetTune();

                    if(curmode == SensorMode.Single)
                    {
                        r_gradient.Checked = false;
                        r_single.Checked = true;
                    }
                    else
                    {
                        r_gradient.Checked = true;
                        r_single.Checked = false;
                    }

                   
                    if (tune.Mode == TuneMode.Auto) 
                        c_aut.Checked = true;
                    else
                        c_aut.Checked = false;

                    n_tuneup.Value = tune.UpField;
                    n_tunedown.Value = tune.DownField;

                    autoTune = c_aut.Checked;
                }
                else
                {
                    pmgSerial.Close();
                    b_open_close.Text = "Open";
                    portOpen = false;
                    b_set.Enabled = false;
                    b_measure.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_set_Click(object sender, EventArgs e)
        {
            try
            {
                if (r_single.Checked)
                {
                    pmgSerial.SetMode(SensorMode.Single);
                }
                else
                {
                    pmgSerial.SetMode(SensorMode.Gradient);
                }

                Tune tune = new Tune();
                if (c_aut.Checked)
                    tune.Mode = TuneMode.Auto;
                else
                    tune.Mode = TuneMode.Manual;

                tune.UpField = (int)n_tuneup.Value;
                tune.DownField = (int)n_tunedown.Value;

                pmgSerial.SetTune(tune);

                autoTune = c_aut.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void b_measure_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                b_set.Enabled = false;
                b_measure.Enabled = false;
                MeasuredData mesdata = new MeasuredData();
                mesdata = pmgSerial.Measure();

                int sensorStatus = (mesdata.Status >> 8) & 0xff;
                int errCode = mesdata.Status & 0xff;
                int tuneStatus = errCode;
                if (sensorStatus == 0)
                {
                    if (mesdata.DownField == 0)
                    {
                        l_timestamp.Text = mesdata.TimeStamp.ToString();
                        l_field.Text = Math.Round(mesdata.Field, 2).ToString();
                        l_error.Text = "±" + Math.Round(mesdata.Error, 2).ToString() + " nT";
                        l_upfield.Text = Math.Round(mesdata.Field, 2).ToString() + " nT";
                        l_downfield.Text = Math.Round(mesdata.DownField, 2).ToString() + " nT";
                        l_amplitude.Text = mesdata.Amplitude.ToString();
                        l_decay.Text = Math.Round(mesdata.Decay, 1).ToString() + " s";

                        //n_tuneup.Value = n_tunedown.Value = (int)Math.Round(mesdata.Field);
                    }
                    else
                    {
                        l_timestamp.Text = mesdata.TimeStamp.ToString();
                        l_field.Text = Math.Round(mesdata.Field, 2).ToString();
                        l_error.Text = "±" + Math.Round(mesdata.Error, 2).ToString() + " nT";
                        l_upfield.Text = Math.Round(mesdata.Field + mesdata.DownField, 2).ToString() + " nT";
                        l_downfield.Text = Math.Round(mesdata.DownField, 2).ToString() + " nT";
                        l_amplitude.Text = mesdata.Amplitude.ToString();
                        l_decay.Text = Math.Round(mesdata.Decay, 1).ToString() + " s";

                        /*n_tuneup.Value = (int)Math.Round(mesdata.Field + mesdata.DownField);
                        n_tunedown.Value = (int)Math.Round(mesdata.DownField);*/
                    }

                }
                else
                {
                    String ErrorText;
                    if (sensorStatus == PMG2Serial.SensorCheckUp)
                        ErrorText = "Check up sensor";
                    else if (sensorStatus == PMG2Serial.SensorCheckDown)
                        ErrorText = "Check down sensor";
                    else if (sensorStatus == PMG2Serial.SensorCheckBooth)
                        ErrorText = "Check up/down sensor";
                    else
                        ErrorText = "Low voltage cannot measure";
                   

                    throw new Exception(ErrorText);
                }

                if (tuneStatus != 0)
                {
                    String ErrorText;
                    int tuneErr = errCode & (PMG2Serial.TuneUpCanNotTune | PMG2Serial.TuneDownCanNotTune);
                    int tuneChanged = errCode & (PMG2Serial.TuneUpTuneChanged | PMG2Serial.TuneDownTuneChanged);
                    if (autoTune)
                    {
                        if (tuneErr == PMG2Serial.TuneUpCanNotTune)
                            ErrorText = "Up sensor cannot tune";
                        else if (tuneErr == PMG2Serial.TuneDownCanNotTune)
                            ErrorText = "Down sensor cannot tune";
                        else
                            ErrorText = "Up/Down sensor cannot tune";

                        if (tuneErr == 0)
                            if (tuneChanged == PMG2Serial.TuneUpTuneChanged)
                                ErrorText = "Up sensor tune changed";
                            else if (tuneChanged == PMG2Serial.TuneDownTuneChanged)
                                ErrorText = "Down sensor tune changed";
                            else
                                ErrorText = "Up/Down sensor tune changed";

                        throw new Exception(ErrorText);
                    }
                    else
                    {
                        if (tuneErr == PMG2Serial.TuneUpCanNotTune)
                            ErrorText = "Up sensor cannot tune out of range";
                        else if (tuneErr == PMG2Serial.TuneDownCanNotTune)
                            ErrorText = "Down sensor cannot tune out of range";
                        else
                            ErrorText = "Up/Down sensor cannot tune out of range";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                b_set.Enabled = true;
                b_measure.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            pmgSerial.Close();
        }
    }
}
