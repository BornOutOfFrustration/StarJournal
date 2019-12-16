using StarJournalGuiWpfTest.ApplicationAccess;

namespace StarJournalGuiWpfTest.Helpers
{
    interface IApp
    {
        IApp Initialize();

        bool Start();
        IApp Stop(out bool stopped);

        AppUnderTest App { get; }
    }
}
