using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Views.Shared;

public partial class BackpackView : UserControl
{
    public BackpackView()
    {
        InitializeComponent();
    }
    
    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (DragAdorner.IsVisible)
        {
            var pos = e.GetPosition(this);
            ((TranslateTransform)DragAdorner.RenderTransform!).X = pos.X + 10;
            ((TranslateTransform)DragAdorner.RenderTransform!).Y = pos.Y + 10;
        }
    }
    
    private async void Slot_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Border border &&
            border.Tag is ItemSlot sourceSlot &&
            sourceSlot.Item is { } item)
        {
            var data = new DataObject();
            data.Set("sourceSlot", sourceSlot);

            await DragDrop.DoDragDrop(e, data, DragDropEffects.Move);
        }
    }

    private void Slot_DragOver(object? sender, DragEventArgs e)
    {
        if (e.Data.Contains("sourceSlot"))
        {
            e.DragEffects = DragDropEffects.Move;
        }
    }

    private void Slot_Drop(object? sender, DragEventArgs e)
    {
        if (sender is Border border &&
            border.Tag is ItemSlot targetSlot &&
            e.Data.Get("sourceSlot") is ItemSlot sourceSlot)
        {
            // Swap items
            var temp = targetSlot.Item;
            targetSlot.Item = sourceSlot.Item;
            sourceSlot.Item = temp;
        }
    }
}