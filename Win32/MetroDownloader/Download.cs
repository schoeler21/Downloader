using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.ComponentModel;

namespace MetroDownloader
{
    public class Download
    {

        /// <summary>
        /// Der aktuelle Status des Downloads
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Die URL des Downloads
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Aktueller Download-Speed
        /// </summary>
        public string downloadSpeed { get; set; }
        /// <summary>
        /// Downloadfortschritt in Prozent
        /// </summary>
        public int progress { get; set; }
        /// <summary>
        /// True, wenn ein Fehler aufgetreten ist
        /// </summary>
        private bool failed = false;

        /// <summary>
        /// Konstruktor für einen neuen Download
        /// </summary>
        /// <param name="_url">Datei URL</param>
        /// <param name="_filename">Lokaler Pfad zum Speichern</param>
        public Download(string _url, string _filename)
        {

            this.status = DownloadStatus.Downloading.ToString();
            url = _url;
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                webClient.DownloadFileAsync(new Uri(_url), _filename);
            } catch (Exception e)
            {
                this.status = "Fehler: " + e.Message;
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn sich der Fortschritt verändert hat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progress = e.ProgressPercentage;
            this.downloadSpeed = "";
        }

        /// <summary>
        /// Wird aufgerufen wenn der Download fertig ist, abgebrochen wurde oder ein Fehler aufgetreten ist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.status = "Fertig";
        }

        

    }

    

    public enum DownloadStatus
    {
        Downloading,
        Failed,
        Finished,
        Paused
    }
}
