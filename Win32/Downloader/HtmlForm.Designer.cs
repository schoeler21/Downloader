/* This program uses 
 CefSharp           Copyright © 2010-2016 The CefSharp Authors, https://github.com/cefsharp/CefSharp (License https://github.com/cefsharp/CefSharp/blob/master/LICENSE)
 jQuery             Copyright JS Foundation and other contributors, https://js.foundation/ (License https://github.com/jquery/jquery/blob/master/LICENSE.txt)
 Bootstrap          Copyright (c) 2011-2016 Twitter, Inc. https://github.com/twbs/bootstrap/ (License https://github.com/twbs/bootstrap/blob/v4-dev/LICENSE)
                    Copyright (c) 2011-2016 The Bootstrap Authors
 Superhero Style    Copyright (c) Copyright 2012-2016 Thomas Park https://bootswatch.com/ (License https://github.com/thomaspark/bootswatch/blob/gh-pages/LICENSE)
 */
namespace Downloader
{
    partial class HtmlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HtmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 489);
            this.Name = "HtmlForm";
            this.Text = "Donwload Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtmlForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

