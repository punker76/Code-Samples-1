using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using MetroProgressBarAnimationTest.ViewModel;

namespace MetroProgressBarAnimationTest.View
{
  public class MainTabView: ContentControl
  {
    static MainTabView()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTabView), new FrameworkPropertyMetadata(typeof(MainTabView)));
    }

    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
      "ViewModel",
      typeof(MainTabViewModel),
      typeof(MainTabView),
      new PropertyMetadata(default(MainTabViewModel)));

    public MainTabViewModel ViewModel
    {
      get
      {
        return (MainTabViewModel)this.GetValue(ViewModelProperty);
      }
      set
      {
        this.SetValue(ViewModelProperty, value);
      }
    }
  }
}