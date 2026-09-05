using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Views;

public partial class MainWindow : Window
{
    private bool _forceClose;

    public MainWindow()
    {
        InitializeComponent();

        AddHandler(DragDrop.DropEvent, OnDrop);
        AddHandler(DragDrop.DragOverEvent, OnDragOver);

        DataContextChanged += (_, _) => PopulateOpenSampleMenu();
        PopulateOpenSampleMenu();

        Closing += MainWindow_Closing;
        this.FindControl<TreeView>("DocumentTree")!.KeyDown += DocumentTree_KeyDown;
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

    private async void CloseTab_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Control { DataContext: DocumentViewModel document } && ViewModel is { } viewModel)
            await CloseDocumentWithConfirmationAsync(viewModel, document);
        e.Handled = true;
    }

    private async void CloseActiveTab_Click(object? sender, RoutedEventArgs e)
    {
        if (ViewModel is { ActiveDocument: { } document } viewModel)
            await CloseDocumentWithConfirmationAsync(viewModel, document);
    }

    /// <summary>Closing a dirty tab asks to confirm first (File &gt; Close, the tab's ✕ button, and
    /// Ctrl+W all go through this). <see cref="DocumentViewModel.IsDirty"/> is all the view model needs to
    /// expose for this -- the confirmation itself is a plain view concern.</summary>
    private async Task CloseDocumentWithConfirmationAsync(MainWindowViewModel viewModel, DocumentViewModel document)
    {
        if (document.IsDirty)
        {
            var confirmed = await ConfirmAsync("Unsaved Changes", $"\"{document.DisplayName}\" has unsaved changes. Close it anyway?");
            if (!confirmed)
                return;
        }

        viewModel.CloseDocumentCommand.Execute(document);
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
        // Loop nodes (and the segment nodes reachable through them) are a separate tree shape from
        // Children -- see DocumentNodeViewModel.LoopChildren -- so Expand/Collapse All has to walk both to
        // reach everything the tree could be showing, in either view mode.
        foreach (var child in node.LoopChildren)
            SetExpandedRecursive(child, expanded);
    }

    private void Exit_Click(object? sender, RoutedEventArgs e) => Close();

    /// <summary>Ctrl+W is handled here rather than a direct KeyBinding so it can confirm before closing a
    /// dirty tab, same as the tab's ✕ button and File &gt; Close.</summary>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.W && e.KeyModifiers == KeyModifiers.Control && ViewModel is { ActiveDocument: { } document } viewModel)
        {
            e.Handled = true;
            _ = CloseDocumentWithConfirmationAsync(viewModel, document);
            return;
        }

        if (e.Key == Key.F && e.KeyModifiers == KeyModifiers.Control && ViewModel is { } vm)
        {
            e.Handled = true;
            OpenSearch(vm);
            return;
        }

        base.OnKeyDown(e);
    }

    /// <summary>Exiting with unsaved changes (the window's own close button included, since this runs on
    /// every Closing) asks to confirm once for every dirty tab.</summary>
    private async void MainWindow_Closing(object? sender, WindowClosingEventArgs e)
    {
        if (_forceClose || ViewModel is not { } viewModel)
            return;

        var dirtyCount = viewModel.Documents.Count(d => d.IsDirty);
        if (dirtyCount == 0)
            return;

        e.Cancel = true;
        var confirmed = await ConfirmAsync(
            "Unsaved Changes",
            dirtyCount == 1
                ? "One document has unsaved changes. Exit anyway?"
                : $"{dirtyCount} documents have unsaved changes. Exit anyway?");

        if (!confirmed)
            return;

        _forceClose = true;
        Close();
    }

    /// <summary>Delete key with the tree focused deletes the selected segment (Edit &gt; Delete Segment does
    /// the same thing; envelope nodes are rejected by DocumentEditor with a status bar message).</summary>
    private void DocumentTree_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.Delete || ViewModel is not { } viewModel)
            return;

        viewModel.DeleteSegmentCommand.Execute(null);
        e.Handled = true;
    }

    /// <summary>Edit &gt; Find… (Ctrl+F goes through OnKeyDown above instead, so both paths share this).</summary>
    private void Find_Click(object? sender, RoutedEventArgs e)
    {
        if (ViewModel is { } viewModel)
            OpenSearch(viewModel);
    }

    private void OpenSearch(MainWindowViewModel viewModel)
    {
        viewModel.OpenSearchCommand.Execute(null);

        var textBox = this.FindControl<TextBox>("SearchTextBox");
        if (textBox is null)
            return;

        // Post rather than focus synchronously: the search bar's Border only just became visible in this
        // same binding pass (IsSearchVisible just flipped true), same reasoning as BeginEditingElement below.
        Dispatcher.UIThread.Post(() =>
        {
            textBox.Focus();
            textBox.SelectAll();
        }, DispatcherPriority.Loaded);
    }

    private async void InsertSegmentAfter_Click(object? sender, RoutedEventArgs e) => await InsertSegmentAsync(before: false);

    private async void InsertSegmentBefore_Click(object? sender, RoutedEventArgs e) => await InsertSegmentAsync(before: true);

    private async Task InsertSegmentAsync(bool before)
    {
        if (ViewModel is not { } viewModel)
            return;

        var text = await PromptForSegmentTextAsync(before ? "Insert Segment Before" : "Insert Segment After");
        if (text is null)
            return;

        viewModel.InsertSegment(before, text);
    }

    /// <summary>Double-click on the Value cell's text opens the in-place editor.</summary>
    private void ElementValueText_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Control { DataContext: ElementViewModel element } control)
            BeginEditingElement(element, control);
        e.Handled = true;
    }

    /// <summary>F2 on a focused Value cell opens the in-place editor.</summary>
    private void ElementValueText_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.F2 || sender is not Control { DataContext: ElementViewModel element } control)
            return;

        BeginEditingElement(element, control);
        e.Handled = true;
    }

    private static void BeginEditingElement(ElementViewModel element, Control textBlock)
    {
        element.EditText = element.Value ?? "";
        element.IsEditing = true;

        // The TextBox sharing this cell is the TextBlock's sibling in the same Grid; give it focus once
        // it has actually become visible (Post, rather than focusing synchronously into a control that
        // is still IsVisible="False" at this point in the binding pass).
        if (textBlock.Parent is Panel panel)
        {
            Dispatcher.UIThread.Post(() =>
            {
                var textBox = panel.Children.OfType<TextBox>().FirstOrDefault();
                textBox?.Focus();
                textBox?.SelectAll();
            }, DispatcherPriority.Loaded);
        }
    }

    /// <summary>Enter commits the edit (see MainWindowViewModel.SetElementValue); Escape cancels it.</summary>
    private void ElementValueEditor_KeyDown(object? sender, KeyEventArgs e)
    {
        if (sender is not TextBox { DataContext: ElementViewModel element })
            return;

        if (e.Key == Key.Enter)
        {
            CommitElementEdit(element);
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            element.IsEditing = false;
            e.Handled = true;
        }
    }

    /// <summary>Clicking away from the editor without pressing Enter cancels the edit rather than silently
    /// committing it.</summary>
    private void ElementValueEditor_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (sender is TextBox { DataContext: ElementViewModel element } && element.IsEditing)
            element.IsEditing = false;
    }

    private void CommitElementEdit(ElementViewModel element)
    {
        element.IsEditing = false;

        if (ViewModel is not { ActiveDocument: { SelectedNode: { } node } document } viewModel)
            return;

        viewModel.SetElementValue(document, node, element, element.EditText);
    }

    /// <summary>Small Yes/No modal used for close/exit confirmation.</summary>
    private async Task<bool> ConfirmAsync(string title, string message)
    {
        var tcs = new TaskCompletionSource<bool>();
        var yes = new Button { Content = "Yes", IsDefault = true, MinWidth = 72 };
        var no = new Button { Content = "No", IsCancel = true, MinWidth = 72 };

        var dialog = new Window
        {
            Title = title,
            Width = 380,
            SizeToContent = SizeToContent.Height,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(20),
                Spacing = 16,
                Children =
                {
                    new TextBlock { Text = message, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Spacing = 8,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Children = { yes, no },
                    },
                },
            },
        };

        yes.Click += (_, _) => { tcs.TrySetResult(true); dialog.Close(); };
        no.Click += (_, _) => { tcs.TrySetResult(false); dialog.Close(); };
        dialog.Closed += (_, _) => tcs.TrySetResult(false);

        await dialog.ShowDialog(this);
        return await tcs.Task;
    }

    /// <summary>Small modal asking for one line of raw segment text (Edit &gt; Insert Segment After/Before and
    /// the tree's context menu). Returns null when cancelled.</summary>
    private async Task<string?> PromptForSegmentTextAsync(string title)
    {
        var tcs = new TaskCompletionSource<string?>();
        var textBox = new TextBox { Watermark = "e.g. N9*ZZ*VALUE (no terminator)", MinWidth = 320 };
        var ok = new Button { Content = "Insert", IsDefault = true, MinWidth = 72 };
        var cancel = new Button { Content = "Cancel", IsCancel = true, MinWidth = 72 };

        var dialog = new Window
        {
            Title = title,
            Width = 420,
            SizeToContent = SizeToContent.Height,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Thickness(20),
                Spacing = 12,
                Children =
                {
                    new TextBlock { Text = "Segment text, without a terminator:" },
                    textBox,
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Spacing = 8,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Children = { ok, cancel },
                    },
                },
            },
        };

        ok.Click += (_, _) => { tcs.TrySetResult(textBox.Text); dialog.Close(); };
        cancel.Click += (_, _) => { tcs.TrySetResult(null); dialog.Close(); };
        dialog.Closed += (_, _) => tcs.TrySetResult(null);

        await dialog.ShowDialog(this);
        return await tcs.Task;
    }

    private void LoadedMetadata_Click(object? sender, RoutedEventArgs e)
    {
        var packs = ViewModel?.LoadedPacks ?? new ObservableCollection<PackInfoViewModel>();

        var list = new ListBox
        {
            ItemsSource = packs,
            Background = Brushes.Transparent,
            ItemTemplate = new FuncDataTemplate<PackInfoViewModel>((pack, _) => new StackPanel
            {
                Margin = new Thickness(0, 3),
                Children =
                {
                    new TextBlock { Text = $"{pack.Name}", FontWeight = Avalonia.Media.FontWeight.SemiBold },
                    new TextBlock
                    {
                        Text = $"{pack.Standard} {pack.Version} · {pack.Source}",
                        Classes = { "subtitle" },
                    },
                },
            }),
        };

        var content = packs.Count > 0
            ? (Control)list
            : new TextBlock { Text = "No metadata packs are loaded.", Margin = new Thickness(4) };

        var dialog = new Window
        {
            Title = "Loaded Metadata",
            Width = 420,
            Height = 320,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new ScrollViewer { Content = content, Margin = new Thickness(16) },
        };
        dialog.ShowDialog(this);
    }

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
