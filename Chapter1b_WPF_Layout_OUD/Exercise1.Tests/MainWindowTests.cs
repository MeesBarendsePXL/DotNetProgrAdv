﻿using Guts.Client.Core;
using Guts.Client.Core.TestTools;
using Guts.Client.WPF.TestTools;
using System.Windows;
using System.Windows.Controls;

namespace Exercise1.Tests
{
    [ExerciseTestFixture("progAdvNet", "H01b", "Exercise01", @"Exercise1\MainWindow.xaml")]
    [Apartment(ApartmentState.STA)]
    public class MainWindowTests
    {
        private TestWindow<MainWindow> _window;
        private DockPanel _dockPanel;
        private Grid _grid;
        private WrapPanel _wrapPanel;
        private StackPanel _stackPanel;

        [OneTimeSetUp]
        public void Setup()
        {
            _window = new TestWindow<MainWindow>();

            _dockPanel = _window.GetUIElements<DockPanel>().FirstOrDefault();
            _stackPanel = _window.GetUIElements<StackPanel>().FirstOrDefault();
            _grid = _window.GetUIElements<Grid>().FirstOrDefault();
            _wrapPanel = _window.GetUIElements<WrapPanel>().FirstOrDefault();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _window.Dispose();
        }

        [MonitoredTest("Should not have changed the codebehind file")]
        public void _1_ShouldNotHaveChangedTheCodebehindFile()
        {
            var codeBehindFilePath = @"Exercise1\MainWindow.xaml.cs";
            var fileHash = Solution.Current.GetFileHash(codeBehindFilePath);
            Assert.That(fileHash, Is.EqualTo("57-89-1E-07-47-09-92-39-BD-6C-73-7D-98-70-C3-80"),
                () =>
                    $"The file '{codeBehindFilePath}' has changed. " +
                    "Undo your changes on the file to make this test pass. " +
                    "This exercise can be completed by purely working with XAML.");
        }

        [MonitoredTest("All buttons should have some margin")]
        public void _2_AllButtonsShouldHaveSomeMargin()
        {
            Assert.That(_dockPanel, Is.Not.Null, () => "No 'DockPanel' could be found.");
            var allButtons = _dockPanel.FindVisualChildren<Button>().ToList();

            Assert.That(allButtons,
                Has.All.Matches((Button button) => HasMargin(button)),
                () => "All 'Button' elements in the XAML should have some margin on all sides. " +
                      "E.g. 'Margin=\"4\"'");
        }

        [MonitoredTest("None of the buttons should be aligned to the left or the top")]
        public void _3_NoneOfTheButtonsShouldBeAlignedToTheLeftOrTheTop()
        {
            Assert.That(_dockPanel, Is.Not.Null, () => "No 'DockPanel' could be found.");
            var allButtons = _dockPanel.FindVisualChildren<Button>().ToList();

            Assert.That(allButtons,
                Has.None.Matches((Button button) => button.HorizontalAlignment == HorizontalAlignment.Left),
                "There is at least one 'Button' that has 'HorizontalAlignment' left.");

            Assert.That(allButtons,
                Has.None.Matches((Button button) => button.VerticalAlignment == VerticalAlignment.Top),
                "There is at least one 'Button' that has 'VerticalAlignment' top.");
        }

        [MonitoredTest("Should have a dockpanel with a button and a grid")]
        public void _4_ShouldHaveADockPanelWithAButtonAndAGrid()
        {
            Assert.That(_dockPanel, Is.Not.Null, () => "No 'DockPanel' could be found.");
            Assert.That(_dockPanel.Parent, Is.EqualTo(_window.Window),
                () => "The 'DockPanel' should be the child element (content) of 'Window'.");

            var buttons = _dockPanel.Children.OfType<Button>().ToList();
            Assert.That(buttons, Has.Count.EqualTo(1), "The 'DockPanel' should have exactly one 'Button' child element.");
            var button = buttons.First();
            Assert.That(DockPanel.GetDock(button), Is.EqualTo(Dock.Right),
                () => "The 'Button' should be docked on the right.");
            Assert.That(button.HorizontalAlignment, Is.EqualTo(HorizontalAlignment.Stretch),
                () => "The 'Button' should 'Stretch' to the borders of its parent.");
            Assert.That(button.VerticalAlignment, Is.EqualTo(VerticalAlignment.Stretch),
                () => "The 'Button' should 'Stretch' to the borders of its parent.");

            var grid = _dockPanel.Children.OfType<Grid>().FirstOrDefault();
            Assert.That(grid, Is.Not.Null, "The 'DockPanel' should have a 'Grid' child element.");
            Assert.That(grid, Is.EqualTo(_grid),
                "Multiple 'Grid' elements are found. There should be only one 'Grid' in the XAML.");
        }

        [MonitoredTest("Should have a stackpanel in the right button")]
        public void _5_ShouldHaveAStackPanelInTheRightButton()
        {
            Assert.That(_stackPanel, Is.Not.Null, () => "No 'StackPanel' could be found.");
            Assert.That(_stackPanel.Parent, Is.TypeOf<Button>(),
                () => "The 'StackPanel' should be the child element (content) of a 'Button'.");

            var button = (Button)_stackPanel.Parent;
            Assert.That(button.Parent, Is.EqualTo(_dockPanel),
                () => "The 'Button' that contains the 'StackPanel' should be a child of the 'DockPanel'.");

            Assert.That(_stackPanel.Orientation, Is.EqualTo(Orientation.Vertical),
                "The 'StackPanel' should have a vertical orientation.");

            var textBlocks = _stackPanel.Children.OfType<TextBlock>().ToList();
            Assert.That(textBlocks, Has.Count.EqualTo(3),
                () => "There should be 3 'TextBlock' elements inside the 'StackPanel'.");

            Assert.That(textBlocks,
                Has.All.Matches((TextBlock textBlock) => HasMargin(textBlock)),
                () => "All 'TextBlock' elements inside the 'StackPanel' should have some margin on all sides. " +
                      "E.g. 'Margin=\"4\"'");

            Assert.That(textBlocks,
                Has.All.Matches((TextBlock textBlock) => !string.IsNullOrEmpty(textBlock.Text)),
                "All 'TextBlock' elements inside the 'StackPanel' should have a non empty Text.");
        }

        [MonitoredTest("Should have a grid with 4 cells arranged correctly")]
        public void _6_ShouldHaveAGridWith4CellsArrangedCorrectly()
        {
            AssertGridHas4Cells();

            var row1Definition = _grid.RowDefinitions[0];
            var row2Definition = _grid.RowDefinitions[1];
            Assert.That(row1Definition.Height.IsStar && row2Definition.Height.IsStar, Is.True,
                () =>
                    "The height of both rows of the 'Grid' should adjust to the height of the 'DockPanel' " +
                    "and thus the height of the 'Window'.");
            Assert.That(row2Definition.ActualHeight, Is.EqualTo(row1Definition.ActualHeight * 3).Within(1.0),
                () => "The second row should always be 3 times higher than the first row.");

            var column1Definition = _grid.ColumnDefinitions[0];
            var column2Definition = _grid.ColumnDefinitions[1];
            Assert.That(column1Definition.Width.IsAbsolute, Is.True,
                () => "The first column of the 'Grid' should have an absolute width (of e.g. 100).");
            Assert.That(column2Definition.Width.IsStar, Is.True,
                () => "The second column of the 'Grid' should take up the remaining space.");
        }

        [MonitoredTest("The grid should have the correct element in each cell")]
        public void _7_TheGridShouldHaveTheCorrectElementInEachCell()
        {
            AssertGridHas4Cells();

            var allGridButtons = _grid.Children.OfType<Button>().ToList();

            Assert.That(allGridButtons, Has.Count.EqualTo(3), "There should be exactly 3 buttons in the Grid.");

            AssertCellHasButton(allGridButtons, 0, 0);
            AssertCellHasButton(allGridButtons, 0, 1);
            AssertCellHasButton(allGridButtons, 1, 0);

            Assert.That(allGridButtons, Has.All.Matches((Button b) =>
            {
                var content = b.Content as string;
                return !string.IsNullOrEmpty(content);
            }), "All the buttons in the Grid must have a non-empty string as Content");

            var button10 = allGridButtons.First(button => Grid.GetRow(button) == 1 && Grid.GetColumn(button) == 0);
            Assert.That(button10.VerticalAlignment, Is.EqualTo(VerticalAlignment.Center),
                () => "The button in cell (1,0) should be vertically aligned in the center of the grid cell.");

            Assert.That(allGridButtons, Has.Exactly(2).Matches((Button b) =>
                    b.HorizontalAlignment == HorizontalAlignment.Stretch &&
                    b.VerticalAlignment == VerticalAlignment.Stretch),
                "The buttons in cells (0,0) and (0,1) should stretch in both directions.");

            var wrapPanel = _grid.Children.OfType<WrapPanel>().FirstOrDefault();
            Assert.That(wrapPanel, Is.Not.Null, () => "No 'WrapPanel' found in the 'Grid'.");
            Assert.That(wrapPanel, Is.EqualTo(_wrapPanel),
                "Multiple 'WrapPanel' elements are found. There shoul be only one 'WrapPanel' in the XAML.");
            Assert.That(Grid.GetRow(wrapPanel) == 1 && Grid.GetColumn(wrapPanel) == 1, Is.True,
                () => "No 'WrapPanel' found in cell (1,1).");
        }

        [MonitoredTest("The wrappanel should have at least 5 buttons with some padding")]
        public void _8_TheWrapPanelShouldHaveAtLeast5Buttons()
        {
            Assert.That(_wrapPanel, Is.Not.Null, () => "No 'WrapPanel' could be found.");
            var wrapPanelButtons = _wrapPanel.Children.OfType<Button>().ToList();
            Assert.That(wrapPanelButtons, Has.Count.GreaterThanOrEqualTo(5),
                () => "There should at least 5 'Button' elements directly inside the 'WrapPanel'.");

            Assert.That(wrapPanelButtons, Has.All.Matches((Button b) =>
            {
                var content = b.Content as string;
                return !string.IsNullOrEmpty(content);
            }), "All the buttons in the WrapPanel must have a non-empty string as Content");

            Assert.That(wrapPanelButtons, Has.All.Matches((Button button) => HasPadding(button)),
                () => "Not all 'Button' elements inside the 'WrapPanel' have some padding on each side.");
        }

        private static void AssertCellHasButton(List<Button> allGridButtons, int row, int column)
        {
            Assert.That(allGridButtons,
                Has.One.Matches((Button button) => Grid.GetRow(button) == row && Grid.GetColumn(button) == column),
                () => $"No 'Button' found in cell ({row},{column}).");
        }

        private bool HasMargin(FrameworkElement element)
        {
            return element.Margin.Left > 0 &&
                   element.Margin.Top > 0 &&
                   element.Margin.Right > 0 &&
                   element.Margin.Bottom > 0;
        }

        private bool HasPadding(Button button)
        {
            return button.Padding.Left > 0 &&
                   button.Padding.Top > 0 &&
                   button.Padding.Right > 0 &&
                   button.Padding.Bottom > 0;
        }

        private void AssertGridHas4Cells()
        {
            Assert.That(_grid, Is.Not.Null, () => "No 'Grid' could be found.");
            Assert.That(_grid.Parent, Is.EqualTo(_dockPanel),
                () => "The 'Grid' should be a child element of the 'DockPanel'.");

            Assert.That(_grid.RowDefinitions, Has.Count.EqualTo(2), () => "The 'Grid' should have 2 rows defined.");
            Assert.That(_grid.ColumnDefinitions, Has.Count.EqualTo(2), () => "The 'Grid' should have 2 columns defined.");
        }
    }
}

