using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Timers;
using Microsoft.Win32;

namespace MetroDownloader
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static List<Download> downloads;

        public MainWindow()
        {
            InitializeComponent();
            //Timer zum aktualisieren des DataGrids
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += T_Elapsed;
            //Erstellt eine Liste mit der Klasse "Download"
            MainWindow.downloads = new List<Download>();
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Da der Timer einen neuen Thread erstellt, muss hier mit Control.Invoke gearbeitet werden.
            downloadList.Invoke(new Action(Update));
        }

        /// <summary>
        /// Aktualisiert das DataGrid
        /// </summary>
        void Update()
        {
            downloadList.ItemsSource = null;
            downloadList.ItemsSource = downloads;
        }

        /// <summary>
        /// Aufgerufen, wenn man auf "Link hinzufügen" klickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            addDownload();
        }

        /// <summary>
        /// Öffnet einen InputDialog und erstellt einen Download mit dem angegebenen Link
        /// </summary>
        public async void addDownload()
        {
            //Öffnet einen InputDialog damit der User die URL eingeben kann.
            string url = await this.ShowInputAsync("URL Hinzufügen", "(bsp. https://domain.bsp/datei.txt)");

            //Erstellt einen SaveFileDialog damit der User den Speicherort angeben kann.
            SaveFileDialog fileDialog = new SaveFileDialog();

            //Dateiname ohne link z.b. datei.txt?arugment
            var fileName = url.Split('/');

            //Dateiname ohne GET argumente z.b. datei.txt
            var fileNameWOA = fileName.Last().Split('?');

            //Dateierweiterung z.b. txt, exe, zip usw
            var extension = fileNameWOA.FirstOrDefault().Split('.').Last();

            fileDialog.FileName = fileNameWOA.FirstOrDefault();

            //Zeigt den SaveFileDialog
            fileDialog.ShowDialog();

            //Fügt den die URL der Liste hinzu
            MainWindow.downloads.Add(new Download(url, fileDialog.FileName));
        } 
    }
}
