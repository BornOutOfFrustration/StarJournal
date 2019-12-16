namespace Utilities.Commands
{
    using System;
    using System.Windows.Input;

    public sealed class DelegateCommand : ICommand
    {
        private readonly Action LocalExecute;
        private readonly Func<bool> LocalCanExecute;

        public event EventHandler LocalCanExecuteChanged;

        public DelegateCommand(Action execute) : this(execute, new Func<bool>(() => { return true; }))
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.LocalExecute = execute;
            this.LocalCanExecute = canExecute;
        }

        event EventHandler ICommand.CanExecuteChanged {
            add 
            {
                LocalCanExecuteChanged += value;
            }

            remove
            {
                LocalCanExecuteChanged -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.LocalCanExecute.Invoke();
        }

        void ICommand.Execute(object parameter)
        {
            this.LocalExecute.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            LocalCanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
