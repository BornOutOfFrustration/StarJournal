namespace StarJournalGuiWpfTest.ApplicationAccess
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using FlaUI.Core;

    internal class AppUnderTest : IDisposable
    {
        internal bool StartApp()
        {                       
            string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string applicationPath = Path.Combine(
                applicationDirectory,
                @"..\..\..\..\StarJournalGuiWpf\bin\Debug\StarJournalGuiWpf.exe");

            var process = Process.Start(applicationPath);

            this.LocalApp = Application.AttachOrLaunch(process.StartInfo);

            return !this.LocalApp.HasExited;
        }

        private Application LocalApp;

        internal Application App 
        {
            get 
            {
                return this.LocalApp;
            }
        }

        internal bool CloseApp()
        {
            return this.LocalApp.Close();          
        }

        private bool DisposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.DisposedValue)
            {
                if (disposing)
                {
                    this.LocalApp.Dispose();
                }

                this.LocalApp = null;

                this.DisposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
