using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LCTWorks.UniversalPlatformTools
{
    /// <summary>
    /// An implementation of <see cref="ICommand"/> wrapping a method of type <see cref="Action"/>/>.
    /// </summary>
    public class ActionCommand : ICommand
    {
        private Action action;
        /// <summary>
        /// Initializes a new instance of the class ignoring the <see cref="ICommand"/> parameter.
        /// </summary>
        /// <param name="action">The <see cref="Action"/></param>
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public void Execute(object parameter) => action?.Invoke();

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
        private EventHandler CanExcecuteChanged;
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CanExcecuteChanged += value;
            }

            remove
            {
                CanExcecuteChanged -= value;
            }
        }
    }
    /// <summary>
    /// An implementation of <see cref="ICommand"/> wrapping a method of type <see cref="Action{T}"/>/>.
    /// </summary>
    public class ActionCommand<T>: ICommand
    {
        private readonly Action<T> action;

        /// <summary>
        /// Initializes a new instance of the class using a parameter to pass by the <see cref="ICommand.Execute(object)"/> method.
        /// </summary>
        /// <param name="action"></param>
        public ActionCommand(Action<T> action)
        {
            this.action = action;
        }
        public void Execute(T parameter) => action?.Invoke(parameter);

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        private EventHandler CanExcecuteChanged;
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CanExcecuteChanged += value;
            }

            remove
            {
                CanExcecuteChanged -= value;
            }
        }
    }
}
