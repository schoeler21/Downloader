/* This program uses 
 CefSharp           Copyright © 2010-2016 The CefSharp Authors, https://github.com/cefsharp/CefSharp (License https://github.com/cefsharp/CefSharp/blob/master/LICENSE)
 jQuery             Copyright JS Foundation and other contributors, https://js.foundation/ (License https://github.com/jquery/jquery/blob/master/LICENSE.txt)
 Bootstrap          Copyright (c) 2011-2016 Twitter, Inc. https://github.com/twbs/bootstrap/ (License https://github.com/twbs/bootstrap/blob/v4-dev/LICENSE)
                    Copyright (c) 2011-2016 The Bootstrap Authors
 Superhero Style    Copyright (c) Copyright 2012-2016 Thomas Park https://bootswatch.com/ (License https://github.com/thomaspark/bootswatch/blob/gh-pages/LICENSE)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HtmlForm());
        }
    }
}
