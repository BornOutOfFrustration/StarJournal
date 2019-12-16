namespace StarJournalGuiWpfTest.Helpers
{
    using StarJournalGuiWpfTest.ApplicationAccess;

    class AppHelper : IApp
    {
        private IApp LocalAppHelper = new UnInitialized();

        private class UnInitialized : IApp
        {
            AppUnderTest IApp.App
            {
                get
                {
                    throw new System.NotImplementedException();
                }
            }

            IApp IApp.Initialize()
            {
                IApp x = new Initialized();
                return x.Initialize();
            }

            bool IApp.Start()
            {
                throw new System.NotImplementedException();
            }

            IApp IApp.Stop(out bool stopped)
            {
                throw new System.NotImplementedException();
            }
        }

        private class Initialized : IApp
        {                        
            IApp IApp.Initialize()
            {
                _ = this.Start();
                return this;
            }

            private readonly AppUnderTest LocalAppUnderTest = new AppUnderTest();

            internal AppUnderTest App
            {
                get
                {
                    return this.LocalAppUnderTest;
                }
            }

            AppUnderTest IApp.App
            {
                get
                {
                    return this.LocalAppUnderTest;
                }
            }

            private bool Start()
            {
                return this.LocalAppUnderTest.StartApp();
            }

            bool IApp.Start()
            {
                return this.Start();
            }

            IApp IApp.Stop(out bool stopped)
            {
                stopped = this.LocalAppUnderTest.CloseApp();
                this.LocalAppUnderTest.Dispose();
                return new UnInitialized();
            }
        }

        IApp IApp.Initialize()
        {
            this.LocalAppHelper = this.LocalAppHelper.Initialize();
            return this.LocalAppHelper;
        }

        bool IApp.Start()
        {
            return this.LocalAppHelper.Start();
        }

        IApp IApp.Stop(out bool stopped)
        {
            this.LocalAppHelper = this.LocalAppHelper.Stop(out stopped);
            return this.LocalAppHelper;
        }

        AppUnderTest IApp.App
        {
            get
            {
                return this.LocalAppHelper.App;
            }
        }
    }
}
