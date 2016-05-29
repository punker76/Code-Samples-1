using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace MetroProgressBarAnimationTest.Components
{
  public class DelegateCommand: ICommand
  {
#pragma warning disable 0067
    public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

    private readonly Action _callback;

    public DelegateCommand(Action callback)
    {
      this._callback = callback;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      this._callback.Invoke();
    }
  }
}