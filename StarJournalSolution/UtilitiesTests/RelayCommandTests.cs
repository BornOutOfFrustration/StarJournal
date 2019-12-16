using Utilities.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using System;

namespace UtilitiesTests
{
    [TestClass()]
    public class RelayCommandTests
    {
        [TestMethod()]
        public void TestExecute()
        {
            bool b = false;
            var action = new Action(()=> { b = true; });
            ICommand cmd = new DelegateCommand(action, null);

            cmd.Execute(null);

            Assert.IsTrue(b);
        }

        [DataTestMethod()]
        [DataRow(true, "Can Execute command.")]
        [DataRow(false, "Can't Execute command.")]
        public void TestCanExecute(bool canExecute, string name)
        {
            var function = new Func<bool>(() => { return canExecute; });

            ICommand cmd = new DelegateCommand(null, function);

            Assert.AreEqual<bool>(canExecute, cmd.CanExecute(null), name);
        }
    }
}