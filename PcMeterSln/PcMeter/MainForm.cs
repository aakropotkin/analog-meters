/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// PcMeter MainForm.cs
//
// Display CPU load% and Committed Memory% and send to PC meter device via serial port.
//
// PC Meter application
//
// http://www.lungStruck.com/projects/pc-meter
// Visit the webpage for more information including info on the arduino-based meter I built that is driven by this program.
//
// Revised 5/20/2015 - Switched from using PerformanceCounter("Memory", "% Committed Bytes In Use", ""); for memory (which is actually page file usage)
//                     to using Antonio Bakula's GetPerformanceInfo code. Thanks to mnedix for bringing the issue to my attention. You can see what he
//                     did using my code at http://www.instructables.com/id/Nixie-PC-MeterMonitor/.
//
// Copyright (c) Scott W. Vincent, 2013, 2015
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//  - Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//
//  - Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer
//    in the documentation and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,
// BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT
// SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;           //Performance counters
using System.IO;                    //Serial
using System.IO.Ports;              //Serial
using PcMeter.Properties;           //Settings load/save

namespace PcMeter
{
    public partial class MainForm : Form
    {

        #region Form variables/objects

        //Form variables/objects
        private PerformanceCounter cpuCounter;      //For CPU stats
        PerfomanceInfoData perfData;                //For memory %
        private SerialPort meterPort;               //Serial port
        private bool exitApp = false;               //True if exiting app, for proper form closing

        #endregion Form variables/objects

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Counters Init/Dispose

        /// <summary>
        /// Initialize performance counters
        /// </summary>
        /// <returns></returns>
        private bool InitCounters()
        {
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                return true;
            }
            catch
            {
                MessageBox.Show("The performance counter(s) could not be initialized. The program cannot continue.", "Perf. Counter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// Dispose counter objects
        /// </summary>
        private void DisposeCounters()
        {
            try
            {
                // dispose of the counters
                if (cpuCounter != null)
                { cpuCounter.Dispose(); }
            }
            finally
            { PerformanceCounter.CloseSharedResources(); }
        }

        #endregion Counters Init/Dispose

        #region Serial

        /// <summary>
        /// Initialize serial port and connect.  Display error if any occur.
        /// If program is minimized, then display brief message using balloon tip instead.
        /// </summary>
        /// <returns></returns>
        private bool InitSerial()
        {
            string portName = "COM" + comPortUpDown.Value.ToString();

            try
            {
                meterPort = new SerialPort(portName, 9600);
                meterPort.Open();
                DisplayBalloon(true, portName);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                if (this.WindowState == FormWindowState.Normal)
                    MessageBox.Show("The serial port could not be opened.  Check to be sure a valid serial port is selected.",
                        "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    DisplayBalloon(false, portName);
                return false;
            }
            catch (IOException)
            {
                if (this.WindowState == FormWindowState.Normal)
                    MessageBox.Show("The serial port could not be opened.  Check to be sure a valid serial port is selected.",
                        "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    DisplayBalloon(false, portName);
                return false;
            }
            catch (Exception caught)
            {
                if (this.WindowState == FormWindowState.Normal)
                    WinFormHelper.DisplayErrorMessage("Initializing serial port", caught);
                else
                    DisplayBalloon(false, portName);
                return false;
            }
        }


        private bool DisposeSerial()
        {
            try
            {
                if (meterPort != null)
                {
                    if (meterPort.IsOpen)
                        meterPort.Close();
                    meterPort.Dispose();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        private void DisplayBalloon(bool success, string comPort)
        {
            if (success)
            {
                mainNotifyIcon.BalloonTipText = "Connected to " + comPort;
                mainNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            }
            else
            {
                mainNotifyIcon.BalloonTipText = "Failed to connect to " + comPort;
                mainNotifyIcon.BalloonTipIcon = ToolTipIcon.Error;
            }

            mainNotifyIcon.ShowBalloonTip(2000);
        }

        #endregion Serial

        #region Settings

        /// <summary>
        /// Save settings
        /// </summary>
        private void SaveSettings()
        {
            Settings.Default.ComPort = (int)comPortUpDown.Value;
            Settings.Default.ConnectOnStartup = connectOnStartupCheckbox.Checked;
            Settings.Default.StartupSystemTray = startupInSystemTrayCheckbox.Checked;
            Settings.Default.Save();
        }


        /// <summary>
        /// Load settings
        /// </summary>
        private void LoadSettings()
        {
            comPortUpDown.Value = Settings.Default.ComPort;
            connectOnStartupCheckbox.Checked = Settings.Default.ConnectOnStartup;
            startupInSystemTrayCheckbox.Checked = Settings.Default.StartupSystemTray;
        }

        #endregion Settings

        #region Event Handlers

        /// <summary>
        /// Form load, get things going
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            if (startupInSystemTrayCheckbox.Checked)
            {
                //Start in system tray
                mainNotifyIcon.Visible = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }

            if (connectOnStartupCheckbox.Checked)
            {
                //Connect serial on startup
                if (InitSerial())
                {
                    connectButton.Text = "Dis&connect";
                    comPortUpDown.Enabled = false;
                }
            }

            if (InitCounters())
            {
                meterTimer.Enabled = true;
            }
            else
            {
                //Init counters failed, goodbye
                Close();
            }
        }


        /// <summary>
        /// Update performance stats on timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meterTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string cpuPerc = Math.Round(cpuCounter.NextValue(), MidpointRounding.AwayFromZero).ToString();

                perfData = PsApiWrapper.GetPerformanceInfo();
                string memPerc = Math.Round(100 - (((decimal)perfData.PhysicalAvailableBytes / (decimal)perfData.PhysicalTotalBytes) * 100), MidpointRounding.AwayFromZero).ToString();

                cpuTextBox.Text = cpuPerc;
                memTextBox.Text = memPerc;

                if (connectButton.Text == "Dis&connect")
                {
                    string portData = "C" + cpuPerc + "\rM" + memPerc + "\r";
                    meterPort.Write(portData);
                }
            }
            catch (IOException)
            {
                //Serial failed, maybe device was unplugged?  Disable serial and resume.
                //Disable timer (so we only see error once)
                meterTimer.Enabled = false;
                //Dispose serial
                DisposeSerial();
                //Change form back
                connectButton.Text = "&Connect";
                comPortUpDown.Enabled = true;
                MessageBox.Show("Communication with the device has been lost.  Has it been unplugged?", "Serial I/O Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Now that serial is disconnected, it's safe to reenable timer.
                meterTimer.Enabled = true;
            }
            catch (Exception caught)
            {
                //Disable timer (so we only see error once)
                meterTimer.Enabled = false;
                WinFormHelper.DisplayErrorMessage("Update meters", caught);
                //Now that the timer is disabled, the program isn't very useful.  Close.
                exitApp = true;
                this.Close();
            }
        }


        /// <summary>
        /// Cleanup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Note: I hate using the bool to indicate that form is closing.  I would use e.CloseReason and call Application.Exit
            //when the app is closing, but the problem is that the form's closing event doesn't get called because the app
            //loses track of the form due to the use of ShowInTaskbar.  See for more info: http://stackoverflow.com/a/13527298
            if (exitApp)
            {
                //Exit form (and app)
                SaveSettings();
                DisposeCounters();
            }
            else
            {
                //Minimize to system tray
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                mainNotifyIcon.Visible = true;
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Exit application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// Connect/disconnect serial connection to device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == "&Connect")
            {
                if (InitSerial())
                {
                    connectButton.Text = "Dis&connect";
                    comPortUpDown.Enabled = false;
                }
            }
            else
            {
                if (DisposeSerial())
                {
                    connectButton.Text = "&Connect";
                    comPortUpDown.Enabled = true;
                }
            }
        }


        /// <summary>
        /// Display about form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }


        /// <summary>
        /// Display form when notify icon is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        #endregion Event Handlers

        #region ToolStrip Menu Event Handlers

        /// <summary>
        /// Display form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainNotifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        /// <summary>
        /// Exit application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApp = true;
            this.Close();
        }

        #endregion ToolStrip Menu Event Handlers

    }
}