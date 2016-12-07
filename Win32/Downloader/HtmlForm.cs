/* This program uses 
 CefSharp           Copyright © 2010-2016 The CefSharp Authors, https://github.com/cefsharp/CefSharp (License https://github.com/cefsharp/CefSharp/blob/master/LICENSE)
 jQuery             Copyright JS Foundation and other contributors, https://js.foundation/ (License https://github.com/jquery/jquery/blob/master/LICENSE.txt)
 Bootstrap          Copyright (c) 2011-2016 Twitter, Inc. https://github.com/twbs/bootstrap/ (License https://github.com/twbs/bootstrap/blob/v4-dev/LICENSE)
                    Copyright (c) 2011-2016 The Bootstrap Authors
 Superhero Style    Copyright (c) Copyright 2012-2016 Thomas Park https://bootswatch.com/ (License https://github.com/thomaspark/bootswatch/blob/gh-pages/LICENSE)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CefSharp referenzen
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;


namespace Downloader
{
    public partial class HtmlForm : Form
    {

        //Variablen
        ChromiumWebBrowser cefBrowser = null;
        NotifyIcon trayIcon;
        ContextMenu trayContext;
        



        /// <summary>
        /// Öffentlicher Konstruktor der HtmlForm-Klasse.
        /// </summary>
        public HtmlForm()
        {
            //Erstellt ein ContextMenu für das TrayIcon und fügt die benötigten Buttons hinzu.
            trayContext = new ContextMenu();
            trayContext.MenuItems.Add("DownloadManager öffnen", ShowForm);
            trayContext.MenuItems.Add("Beenden", Exit);

            //Erstellt das TrayIcon und weisst ihm ein Icon und ein ContextMenu zu.
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon(SystemIcons.Application, 16, 16);
            trayIcon.Text = "Download Manager";
            trayIcon.ContextMenu = trayContext;
            trayIcon.Visible = true;
            InitializeComponent();
            InitializeChromium();
            
        }


        /// <summary>
        /// Initialisiert das ChromiumEmbeddedFramework
        /// </summary>
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            cefBrowser = new ChromiumWebBrowser(Environment.CurrentDirectory + "\\html\\downloader.html");
            cefBrowser.RegisterJsObject("native", new JSNative());
            cefBrowser.IsBrowserInitializedChanged += CefBrowser_IsBrowserInitializedChanged;
            //Fügt das Chromium control in die Form ein.
            this.Controls.Add(cefBrowser);
            cefBrowser.Dock = DockStyle.Fill;
        }


        /// <summary>
        /// Versteckt das Fenster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Exit(object sender, EventArgs e)
        {

            //Versteckt das Fenster und das TrayIcon bevor Chromium beendet wird.
            this.Hide();
            trayIcon.Visible = false;
            //Beendet Chromium
            Cef.Shutdown();
            //Beendet das Programm mit dem ExitCode "0"
            Environment.Exit(0);
        }


        /// <summary>
        /// Zeigt das Fenster wieder nachdem es Versteckt wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ShowForm(object sender, EventArgs e)
        {
            this.Show();   
        }

        private void CefBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
#if DEBUG
            cefBrowser.ShowDevTools();
#endif
            //cefBrowser.Load(Environment.CurrentDirectory + "\\html\\downloader.html");
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Aufgerufen sobald man auf "Close" klickt.
        private void HtmlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Verhindert, dass das Fenster komplett geschlossen wird.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                this.Hide();
            }



            //Cef.Shutdown();
        }
    }


    /// <summary>
    /// Die brücke zwischen JavaScript und C#
    /// </summary>
    public class JSNative
    {
        public string getDir()
        {

            
             


            return (string)Environment.CurrentDirectory;
        }
    }
}
