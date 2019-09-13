using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;           //for Process

namespace PcMeter
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load link and license text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutForm_Load(object sender, EventArgs e)
        {
            const string WEB_LINK = "http://www.lungStruck.com/projects/pc-meter";
            const string LICENSE_TEXT = @"Copyright (c) Scott W. Vincent, 2013
All rights reserved.
            
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
            
  - Redistributions of source code must retain the above copyright notice, this list of conditions and the
    following disclaimer.

  - Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the
    following disclaimer in the documentation and/or other materials provided with the distribution.
        
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS"" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.";

            pcMeterLinkLabel.Text = WEB_LINK;
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = WEB_LINK;
            pcMeterLinkLabel.Links.Add(link);
            licenseTextBox.Text = LICENSE_TEXT;
        }

        
        /// <summary>
        /// Close about form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Load website.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcMeterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}