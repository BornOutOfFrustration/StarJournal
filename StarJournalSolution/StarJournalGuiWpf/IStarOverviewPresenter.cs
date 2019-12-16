namespace StarJournalGuiWpf
{
    using System;

    public interface IStarOverviewPresenter
    {
        event EventHandler StarItemChanged;

        bool IsNew { get; }
        string ItemName { get; }
    }
}
