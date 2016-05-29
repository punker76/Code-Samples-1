using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using MetroProgressBarAnimationTest.ViewModel;

namespace MetroProgressBarAnimationTest.View
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    private static readonly DependencyPropertyKey _viewModelProperty = DependencyProperty.RegisterReadOnly(
      "ViewModel",
      typeof(MainViewModel),
      typeof(MainWindow),
      new PropertyMetadata(default(MainViewModel)));

    public static readonly DependencyProperty ViewModelProperty = _viewModelProperty.DependencyProperty;

    public MainViewModel ViewModel
    {
      get
      {
        return (MainViewModel)this.GetValue(ViewModelProperty);
      }
      private set
      {
        this.SetValue(_viewModelProperty, value);
      }
    }

    public MainWindow()
    {
      this.InitializeComponent();

      this.ViewModel = new MainViewModel();
    }
  }
}