using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        AddHandler(DragDrop.DropEvent, OnDrop);
        AddHandler(DragDrop.DragOverEvent, OnDragOver);

        DataContextChanged += (_, _) => PopulateOpenSampleMenu();
        PopulateOpenSampleMenu();
    }

    private MainWindowViewModel? ViewModel => DataContext as MainWindowViewModel;

    /// <summary>
    /// File &gt; Open Sample is generated from MainWindowViewModel.SampleNames: one MenuItem per
    /// sample, each invoking OpenSampleCommand(name). Built in code-behind because the contract has
    /// no per-item command binding path that avoids relative/ancestor bindings.
    /// </summary>
    private void PopulateOpenSampleMenu()
    {
        var menuItem = this.FindControl<MenuItem>("OpenSampleMenuItem");
        if (menuItem is null)
            return;

        menuItem.Items.Clear();

        var viewModel = ViewModel;
        if (viewModel is null)
            return;

        foreach (var name in viewModel.SampleNames)
        {
            var item = new MenuItem
            {
                Header = name,
                Command = viewModel.OpenSampleCommand,
                CommandParameter = name,
            };
            menuItem.Items.Add(item);
        }
    }

    private void CloseTab_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Control { DataContext: DocumentViewModel document } && ViewModel is { } viewModel)
            viewModel.CloseDocumentCommand.Execute(document);
        e.Handled = true;
    }

    private void DiagnosticsList_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (sender is ListBox { SelectedItem: DiagnosticViewModel diagnostic } && ViewModel?.ActiveDocument is { } document)
            document.SelectedNode = diagnostic.Node;
    }

    private void ExpandAll_Click(object? sender, RoutedEventArgs e) => SetExpanded(true);

    private void CollapseAll_Click(object? sender, RoutedEventArgs e) => SetExpanded(false);

    private void SetExpanded(bool expanded)
    {
        if (ViewModel?.ActiveDocument is not { } document)
            return;

        foreach (var node in document.Nodes)
            SetExpandedRecursive(node, expanded);
    }

    private static void SetExpandedRecursive(DocumentNodeViewModel node, bool expanded)
    {
        node.IsExpanded = expanded;
        foreach (var child in node.Children)
            SetExpandedRecursive(child, expanded);
    }

    private void Exit_Click(object? sender, RoutedEventArgs e) => Close();

    private void About_Click(object? sender, RoutedEventArgs e)
    {
        var version = typeof(MainWindow).Assembly.GetName().Version?.ToString() ?? "0.0.0";
        var about = new Window
        {
            Title = "About Eddy Notepad",
            Width = 360,
            Height = 180,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                Spacing = 8,
                Children =
                {
                    new TextBlock { Text = "Eddy Notepad", FontSize = 18, FontWeight = Avalonia.Media.FontWeight.SemiBold },
                    new TextBlock { Text = $"Version {version}" },
                    new TextBlock
                    {
                        Text = "A cross-platform EDI viewer built on the Eddy parsing libraries.",
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                    },
                },
            },
        };
        about.ShowDialog(this);
    }

    private void OnDragOver(object? sender, DragEventArgs e)
    {
        e.DragEffects = e.DataTransfer.Contains(DataFormat.File) ? DragDropEffects.Copy : DragDropEffects.None;
    }

    private async void OnDrop(object? sender, DragEventArgs e)
    {
        if (ViewModel is not { } viewModel)
            return;

        var files = e.DataTransfer.TryGetFiles();
        if (files is null)
            return;

        foreach (var file in files)
            await viewModel.OpenPathAsync(file.Path.LocalPath);
    }
}
