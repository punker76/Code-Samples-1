using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MetroProgressBarAnimationTest.Components;
using MetroProgressBarAnimationTest.View;

namespace MetroProgressBarAnimationTest.ViewModel
{
  public class MainViewModel: INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private ICommand _addTabCommand;
    private int _tabIndex;
    private MainTabViewModel _selectedTab;

    public ObservableCollection<MainTabViewModel> Tabs {get; private set;}

    public ICommand AddTabCommand
    {
      get
      {
        return this._addTabCommand ?? (this._addTabCommand = new DelegateCommand(this.AddTab));
      }
    }

    public MainTabViewModel SelectedTab
    {
      get
      {
        return this._selectedTab;
      }
      set
      {
        this._selectedTab = value;
        this.OnPropertyChanged();
      }
    }

    public MainViewModel()
    {
      this.Tabs = new ObservableCollection<MainTabViewModel>();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = this.PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AddTab()
    {
      var newTab = new MainTabViewModel(this, string.Format("Tab {0}", this._tabIndex++));

      this.SelectedTab = newTab;

      this.Tabs.Add(newTab);

      // The translation from view model to view is usually done by our ViewFactory.
      newTab.View = new MainTabView
      {
        ViewModel = newTab
      };
    }

    public void RemoveTab(MainTabViewModel mainTabViewModel)
    {
      this.Tabs.Remove(mainTabViewModel);

      if (mainTabViewModel == this.SelectedTab) this.SelectedTab = null;

      // The separation of view and view model is usually done by our ViewFactory.
      var view = mainTabViewModel.View;
      mainTabViewModel.View = null;
      view.ViewModel = null;

      // HINT: Commenting the previous block out and leaving view and view model bound, no warning occurs.
      // This seems clear because the animation will not be interupted.
    }
  }
}