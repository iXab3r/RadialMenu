using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RadialMenu.Controls
{
    /// <summary>
    ///     Interaction logic for RadialMenu.xaml
    /// </summary>
    public class RadialMenu : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register(
                "IsOpen", typeof(bool), typeof(RadialMenu),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty HalfShiftedItemsProperty =
            DependencyProperty.Register(
                "HalfShiftedItems", typeof(bool), typeof(RadialMenu),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty CentralItemProperty =
            DependencyProperty.Register(
                "CentralItem", typeof(RadialMenuCentralItem), typeof(RadialMenu),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IList<RadialMenuItem>), typeof(RadialMenu),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        static RadialMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(RadialMenu), new FrameworkPropertyMetadata(typeof(RadialMenu)));
        }

        public bool IsOpen
        {
            get { return (bool) GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public bool HalfShiftedItems
        {
            get { return (bool) GetValue(HalfShiftedItemsProperty); }
            set { SetValue(HalfShiftedItemsProperty, value); }
        }

        public RadialMenuCentralItem CentralItem
        {
            get { return (RadialMenuCentralItem) GetValue(CentralItemProperty); }
            set { SetValue(CentralItemProperty, value); }
        }

        public IList<RadialMenuItem> ItemsSource
        {
            get { return (IList<RadialMenuItem>) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public override void BeginInit()
        {
            ItemsSource = new List<RadialMenuItem>();
            base.BeginInit();
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            if (ItemsSource != null)
            {
                for (int i = 0, count = ItemsSource.Count; i < count; i++)
                {
                    ItemsSource[i].Index = i;
                    ItemsSource[i].Count = count;
                    ItemsSource[i].HalfShifted = HalfShiftedItems;
                }
            }
            return base.ArrangeOverride(arrangeSize);
        }
    }
}