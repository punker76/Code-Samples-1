using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MetroProgressBarAnimationTest.Components;
using MetroProgressBarAnimationTest.View;

namespace MetroProgressBarAnimationTest.ViewModel
{
  public class MainTabViewModel: INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly MainViewModel _mainViewModel;
    private readonly string _name;
    private bool _isAnimationActive;
    private ICommand _toggleCommand;
    private ICommand _closeTabCommand;
    private MainTabView _view;

    public MainTabViewModel(MainViewModel mainViewModel, string name)
    {
      this._mainViewModel = mainViewModel;
      this._name = name;
      this._isAnimationActive = true;

    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = this.PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public MainTabView View
    {
      get
      {
        return this._view;
      }
      set
      {
        this._view = value;
        this.OnPropertyChanged();
      }
    }

    public string Name
    {
      get
      {
        return this._name;
      }
    }

    public bool IsAnimationActive
    {
      get
      {
        return this._isAnimationActive;
      }
      set
      {
        this._isAnimationActive = value;
        this.OnPropertyChanged();
      }
    }

    public ICommand ToggleCommand
    {
      get
      {
        return this._toggleCommand ?? (this._toggleCommand = new DelegateCommand(this.Toggle));
      }
    }

    public ICommand CloseTabCommand
    {
      get
      {
        return this._closeTabCommand ?? (this._closeTabCommand = new DelegateCommand(this.CloseTab));
      }
    }

    private void Toggle()
    {
      this.IsAnimationActive = !this.IsAnimationActive;
    }

    private void CloseTab()
    {
      this._mainViewModel.RemoveTab(this);
    }
  }
}