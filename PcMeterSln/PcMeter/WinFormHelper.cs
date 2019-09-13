/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// PcMeter WinFormHelper.cs
//
// Contains helper code needed by PcMeter.
//
// PC Meter application
//
// http://www.lungStruck.com/projects/pc-meter
// Visit the webpage for more information including info on the arduino-based meter I built that is driven by this program.
//
// Copyright (c) Scott W. Vincent, 2013
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
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;     //For messagebox

namespace PcMeter
{
    public static class WinFormHelper
    {

        #region Error Handling

        /// <summary>
        /// Simple error message display.
        /// </summary>
        /// <param name="processDescription">Description of process that error occured in</param>
        /// <param name="caught">Exception that was caught</param>
        public static void DisplayErrorMessage(string processDescription, Exception caught)
        {
            StringBuilder b = new StringBuilder();

            b.Append("An error was caught.  Details:\n\nProcess Desc.: " + processDescription);

            Exception c = caught;

            while (c != null)
            {
                string message = "\n\nError Desc.: " + c.Message + "\n\n" +
                "Error Type:" + c.GetType().ToString() + "\n\n" +
                "Stack Trace:\n" + c.StackTrace;
                b.Append(message);
                c = c.InnerException;
            }

            MessageBox.Show(b.ToString(), "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Error Handling

    }
}
