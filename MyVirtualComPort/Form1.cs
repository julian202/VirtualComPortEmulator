using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyVirtualComPort
{
  public partial class Form1 : Form
  {
    string read;
    int mysleeptime;
    delegate void SetTextCallback(string text);

    public Form1()
    {
      InitializeComponent();
      mysleeptime = 0;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      loadPortList();
      /*
      try
      {
        serialPort1.Open();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }*/
     
      //textBox5.Text = trackBar1.Minimum.ToString();
      //textBox6.Text = trackBar1.Maximum.ToString();
      //labelComport.Text = serialPort1.PortName;

      textBox21.Text=Properties.Settings.Default.addToTextboxIfSend1;

      trackBar1.Maximum = Convert.ToInt32(textBox6.Text);
      trackBar2.Maximum = Convert.ToInt32(textBox3.Text);
      trackBar1.Minimum = Convert.ToInt32(textBox5.Text);
      trackBar2.Minimum = Convert.ToInt32(textBox4.Text);
      trackBar3.Minimum = Convert.ToInt32(textBox18.Text);
      trackBar3.Maximum = Convert.ToInt32(textBox17.Text);
      trackBar4.Minimum = Convert.ToInt32(textBox20.Text);
      trackBar4.Maximum = Convert.ToInt32(textBox19.Text);

      textBox7.Text = Properties.Settings.Default.name1;
      textBox8.Text = Properties.Settings.Default.name2;
      textBox9.Text = Properties.Settings.Default.name3;
      textBox10.Text = Properties.Settings.Default.name4;
      textBox11.Text = Properties.Settings.Default.name5;
      textBox12.Text = Properties.Settings.Default.name6;
      textBox13.Text = Properties.Settings.Default.name7;
      textBox14.Text = Properties.Settings.Default.name8;
      textBox15.Text = Properties.Settings.Default.name9;
      textBox16.Text = Properties.Settings.Default.name10;
      textBox22.Text = Properties.Settings.Default.name11;

      textBoxIfRead1.Text = Properties.Settings.Default.textBoxIfRead1;
      textBoxIfRead2.Text = Properties.Settings.Default.textBoxIfRead2;
      textBoxIfRead3.Text = Properties.Settings.Default.textBoxIfRead3;
      textBoxIfRead4.Text = Properties.Settings.Default.textBoxIfRead4;
      textBoxIfRead5.Text = Properties.Settings.Default.textBoxIfRead5;
      textBoxIfRead6.Text = Properties.Settings.Default.textBoxIfRead6;
      textBoxIfRead7.Text = Properties.Settings.Default.textBoxIfRead7;
      textBoxIfRead8.Text = Properties.Settings.Default.textBoxIfRead8;
      textBoxIfRead9.Text = Properties.Settings.Default.textBoxIfRead9;
      textBoxIfRead10.Text = Properties.Settings.Default.textBoxIfRead10;
      textBoxIfRead11.Text = Properties.Settings.Default.textBoxIfRead11;
      textBoxIfSend1.Text = Properties.Settings.Default.textBoxIfSend1;
      try
      {
        trackBar1.Value = Convert.ToInt32(Properties.Settings.Default.textBoxIfSend1);
      }
      catch (Exception)
      {
      }
      textBoxIfSend2.Text = Properties.Settings.Default.textBoxIfSend2;
      //MessageBox.Show(Properties.Settings.Default.textBoxIfSend2);
      trackBar2.Value = Convert.ToInt32(Properties.Settings.Default.textBoxIfSend2);
      textBoxIfSend3.Text = Properties.Settings.Default.textBoxIfSend3;
      textBoxIfSend4.Text = Properties.Settings.Default.textBoxIfSend4;
      textBoxIfSend5.Text = Properties.Settings.Default.radioButtonPressureA;
      textBoxIfSend6.Text = Properties.Settings.Default.textBoxIfSend6;
      textBoxIfSend7.Text = Properties.Settings.Default.textBoxIfSend7;
      textBoxIfSend8.Text = Properties.Settings.Default.textBoxIfSend8;
      textBoxIfSend9.Text = Properties.Settings.Default.textBoxIfSend9;
      textBoxIfSend10.Text = Properties.Settings.Default.radioButtonTempA;
      textBoxIfSend11.Text = Properties.Settings.Default.textBoxIfSend11;
      textBox2.Text = Properties.Settings.Default.textBox2;

    }

    private void loadPortList()
    {
      foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
      {
        //iterate through available ports and add them for selection.
        comboBox1.Items.Add(port);
        //if we have found our last selected port, set it as the selected item.
        if (port == Properties.Settings.Default.COMM)
        {
          comboBox1.SelectedIndex = comboBox1.FindStringExact(port);
          if (serialPort1.IsOpen) //must close serial port before changing the PortName.
          {
            serialPort1.Close();
          }
          serialPort1.PortName = Properties.Settings.Default.COMM;

          try
          {
            serialPort1.Open();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //doRoutine();
    }
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      doRoutine();
    }

    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        clickedSend();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      textBox1.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      textBox2.Text = "";
    }

    private void button3_Click(object sender, EventArgs e)
    {
      textBox1.Text = "";
      textBox2.Text = "";
      textBoxSend2.Text = "";
      textBoxSend3.Text = "";
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      textBoxIfSend1.Text = trackBar1.Value.ToString();
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
      trackBar1.Minimum = Convert.ToInt32(textBox5.Text);
    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {
      trackBar1.Maximum = Convert.ToInt32(textBox6.Text);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      clickedSend();
    }
    private void clickedSend()
    {
      string x = textBox2.Text;
      x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
      serialPort1.Write(x);
    }

    private void button5_Click(object sender, EventArgs e)
    {
      string x = textBox2.Text;
      x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
      serialPort1.Write(x + Environment.NewLine);
    }

    private void button7_Click(object sender, EventArgs e)
    {
      serialPort1.Write(textBoxSend2.Text);
    }

    private void button6_Click(object sender, EventArgs e)
    {
      serialPort1.Write(textBoxSend2.Text + Environment.NewLine);
    }

    private void button9_Click(object sender, EventArgs e)
    {
      serialPort1.Write(textBoxSend3.Text);
    }

    private void button8_Click(object sender, EventArgs e)
    {
      serialPort1.Write(textBoxSend3.Text + Environment.NewLine);
    }

    private void button10_Click(object sender, EventArgs e)
    {
      textBoxSend2.Text = "";
    }

    private void button11_Click(object sender, EventArgs e)
    {
      textBoxSend3.Text = "";
    }

    private void textBoxIfSend1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        trackBar1.Value = Convert.ToInt32(textBoxIfSend1.Text);
      }
      catch (Exception)
      {

      }

      Properties.Settings.Default.textBoxIfSend1 = textBoxIfSend1.Text;
      Properties.Settings.Default.Save();

    }

    private void textBoxIfRead1_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead1 = textBoxIfRead1.Text;
      Properties.Settings.Default.Save();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBox2 = textBox2.Text;
      Properties.Settings.Default.Save();

    }

    private void textBoxIfSend2_TextChanged(object sender, EventArgs e)
    {
      try
      {
        trackBar1.Value = Convert.ToInt32(textBoxIfSend1.Text);

      }
      catch (Exception)
      {

      }
      Properties.Settings.Default.textBoxIfSend2 = textBoxIfSend2.Text;
      Properties.Settings.Default.Save();

    }

    private void textBoxIfRead2_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead2 = textBoxIfRead2.Text;
      Properties.Settings.Default.Save();

    }

    private void textBoxIfRead3_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead3 = textBoxIfRead3.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead4_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead4 = textBoxIfRead4.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead5_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead5 = textBoxIfRead5.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead6_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead6 = textBoxIfRead6.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead7_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead7 = textBoxIfRead7.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend3_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend3 = textBoxIfSend3.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend4_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend4 = textBoxIfSend4.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend5_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend5 = textBoxIfSend5.Text;
      Properties.Settings.Default.Save();
      try
      {
        trackBar3.Value = Convert.ToInt32(textBoxIfSend5.Text);

      }
      catch (Exception)
      {

      }

      if (radioButtonPressureB.Checked)
      {
        Properties.Settings.Default.radioButtonPressureB=textBoxIfSend5.Text;
      }
      if (radioButtonPressureA.Checked)
      {
        Properties.Settings.Default.radioButtonPressureA = textBoxIfSend5.Text;
      }
      if (radioButtonPressureC.Checked)
      {
        Properties.Settings.Default.radioButtonPressureC = textBoxIfSend5.Text;
      }
    }

    private void textBoxIfSend6_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend6 = textBoxIfSend6.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend7_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend7 = textBoxIfSend7.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead8_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead8 = textBoxIfRead8.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend8_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend8 = textBoxIfSend8.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead9_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead9 = textBoxIfRead9.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend9_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend9 = textBoxIfSend9.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfRead10_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead10 = textBoxIfRead10.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend10_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend10 = textBoxIfSend10.Text;
      Properties.Settings.Default.Save();
      try
      {
        trackBar4.Value = Convert.ToInt32(textBoxIfSend5.Text);

      }
      catch (Exception)
      {

      }
      if (radioButtonTempA.Checked)
      {
        Properties.Settings.Default.radioButtonTempA = textBoxIfSend10.Text;
      }
      if (radioButtonTempB.Checked)
      {
        Properties.Settings.Default.radioButtonTempB = textBoxIfSend10.Text;
      }
      if (radioButtonTempC.Checked)
      {
        Properties.Settings.Default.radioButtonTempC = textBoxIfSend10.Text;
      }

    }

    //threadsafe methods:

    private void SetTextbox1(string text)
    {
      if (this.textBox1.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(SetTextbox1);
        this.Invoke(d, new object[] { text });
      }
      else { this.textBox1.Text = text; }
    }



    private void doRoutine()
    {
      read = serialPort1.ReadExisting();
      if (read != "")
      {
        //textBox1.Text = read;
        SetTextbox1(read);

        if (textBoxIfRead1.Text != "")
        {
          if (textBoxIfRead1.Text == read)
          {
            string x = textBoxIfSend1.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

          }
        }



        if (textBoxIfRead2.Text != "")
        {
          if (textBoxIfRead2.Text == read)
          {

            string x = textBoxIfSend2.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline2.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice2.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice2.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }
        if (textBoxIfRead3.Text != "")
        {
          if (textBoxIfRead3.Text == read)
          {

            string x = textBoxIfSend3.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline3.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice3.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice3.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }


        if (textBoxIfRead4.Text != "")
        {

          if (textBoxIfRead4.Text == read)
          {

            string x = textBoxIfSend4.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline4.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice4.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice4.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }

        if (textBoxIfRead5.Text != "")
        {

          if (textBoxIfRead5.Text == read)
          {

            string x = textBoxIfSend5.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline5.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice5.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice5.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }
        if (textBoxIfRead6.Text != "")
        {
          string tb1text = read;
          if (textBoxIfRead6.Text == tb1text.Substring(0, 1)) //Substring is first char only.
          {

            string x = textBoxIfSend6.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline6.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice6.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice6.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }
        if (textBoxIfRead7.Text != "")
        {

          if (textBoxIfRead7.Text == read.Substring(0, 1))
          {

            string x = textBoxIfSend7.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline7.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice7.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice7.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }
          }
        }
        if (textBoxIfRead8.Text != "")
        {

          if (textBoxIfRead8.Text == read.Substring(0, 1))
          {

            string x = textBoxIfSend8.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline8.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice8.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice8.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }
          }
        }
        if (textBoxIfRead9.Text != "")
        {

          if (textBoxIfRead9.Text == read.Substring(0, 1))
          {

            string x = textBoxIfSend9.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline9.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice9.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice9.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }
          }
        }
        if (textBoxIfRead10.Text != "")
        {

          if (textBoxIfRead10.Text == read.Substring(0, 1))
          {

            string x = textBoxIfSend10.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline10.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice10.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice10.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }
          }
        }
        if (textBoxIfRead11.Text != "")
        {
          if (textBoxIfRead11.Text == read)
          {
            string x = textBoxIfSend11.Text;
            x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
            if (checkBoxAddNewline11.Checked)
            {
              serialPort1.Write(x + Environment.NewLine);
              if (checkBoxSendTwice11.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x + Environment.NewLine);
              }
            }
            else
            {
              serialPort1.Write(x);
              if (checkBoxSendTwice11.Checked)
              {
                System.Threading.Thread.Sleep(mysleeptime);
                serialPort1.Write(x);
              }
            }

            //serialPort1.Write(textBoxIfSend2.Text);
          }
        }


      }

    }

    private void textBox7_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name1 = textBox7.Text;
      Properties.Settings.Default.Save();
    }

    private void textBox8_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name2 = textBox8.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox9_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name3 = textBox9.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox10_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name4 = textBox10.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox11_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name5 = textBox11.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox12_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name6 = textBox12.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox13_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name7 = textBox13.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox14_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name8 = textBox14.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox15_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name9 = textBox15.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox16_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name10 = textBox16.Text;
      Properties.Settings.Default.Save();

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
      trackBar2.Maximum = Convert.ToInt32(textBox3.Text);
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
      trackBar2.Minimum = Convert.ToInt32(textBox4.Text);
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
      textBoxIfSend2.Text = trackBar2.Value.ToString();
    }

    private void trackBar3_Scroll(object sender, EventArgs e)
    {
      textBoxIfSend5.Text = trackBar3.Value.ToString();
    }

    private void textBox17_TextChanged(object sender, EventArgs e)
    {
      trackBar3.Maximum = Convert.ToInt32(textBox17.Text);
    }

    private void textBox18_TextChanged(object sender, EventArgs e)
    {
      trackBar3.Minimum = Convert.ToInt32(textBox18.Text);
    }

    private void trackBar4_Scroll(object sender, EventArgs e)
    {
      textBoxIfSend10.Text = trackBar4.Value.ToString();
    }

    private void textBox20_TextChanged(object sender, EventArgs e)
    {
      trackBar4.Minimum = Convert.ToInt32(textBox20.Text);
    }

    private void textBox19_TextChanged(object sender, EventArgs e)
    {
      trackBar4.Maximum = Convert.ToInt32(textBox19.Text);
    }

    private void radioButtonPressureB_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonPressureB.Checked)
      {
        textBoxIfSend5.Text = Properties.Settings.Default.radioButtonPressureB;
      }
    }

    private void radioButtonPressureC_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonPressureC.Checked)
      {
        textBoxIfSend5.Text = Properties.Settings.Default.radioButtonPressureC;
      }
    }

    private void radioButtonPressureA_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonPressureA.Checked)
      {
        textBoxIfSend5.Text = Properties.Settings.Default.radioButtonPressureA;
      }
    }

    private void radioButtonTempA_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonTempA.Checked)
      {
        textBoxIfSend10.Text = Properties.Settings.Default.radioButtonTempA;
      }
    }

    private void radioButtonTempB_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonTempB.Checked)
      {
        textBoxIfSend10.Text = Properties.Settings.Default.radioButtonTempB;
      }
    }

    private void radioButtonTempC_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonTempC.Checked)
      {
        textBoxIfSend10.Text = Properties.Settings.Default.radioButtonTempC;
      }
    }

    private void button12_Click(object sender, EventArgs e)
    {
      textBoxIfSend1.Text = (Convert.ToInt32(textBoxIfSend1.Text)+ Convert.ToInt32(textBox21.Text)).ToString();
    }

    private void button13_Click(object sender, EventArgs e)
    {
      textBoxIfSend1.Text = (Convert.ToInt32(textBoxIfSend1.Text) - Convert.ToInt32(textBox21.Text)).ToString();
    }

    private void textBox21_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.addToTextboxIfSend1 = textBox21.Text;
    }

    private void button14_Click(object sender, EventArgs e)
    {
      string x = textBox2.Text;
      //x = x.Replace("\n", Environment.NewLine);  //so that we can write "\n" withing the string and it will be automatically replaced with newline.
      serialPort1.Write(x + "\n");
    }

    private void textBoxIfRead11_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfRead11 = textBoxIfRead11.Text;
      Properties.Settings.Default.Save();
    }

    private void textBoxIfSend11_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.textBoxIfSend11 = textBoxIfSend11.Text;
      Properties.Settings.Default.Save();
    }

    private void checkBoxSendTwice4_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void checkBoxAddNewline4_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.COMM = comboBox1.Text;
      Properties.Settings.Default.Save();
      if (serialPort1.IsOpen) //must close serial port before changing the PortName.
      {
        serialPort1.Close();
      }
      serialPort1.PortName = Properties.Settings.Default.COMM;
      try
      {
        serialPort1.Open();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {
      comboBox1.Items.Clear();
      loadPortList();
    }

    private void textBox22_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.name11 = textBox22.Text;
      Properties.Settings.Default.Save();
    }
  }
}
