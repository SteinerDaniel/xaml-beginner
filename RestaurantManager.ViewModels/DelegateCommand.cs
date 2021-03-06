﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action m_Execute;
        private readonly Func<bool> m_CanExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute) 
            : this(execute, () => true)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canexecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");

            m_Execute = execute;
            m_CanExecute = canexecute;
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecute == null ? true : m_CanExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(null))
                m_Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}
