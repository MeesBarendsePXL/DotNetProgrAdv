﻿using Guts.Client.Core;
using Guts.Client.WPF.TestTools;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Exercise5.Tests
{
    [ExerciseTestFixture("progAdvNet", "H01b", "Exercise05", @"Exercise5\GridWindow.xaml")]
    [Apartment(ApartmentState.STA)]
    public class GridWindowTests
    {
        private TestWindow<GridWindow> _window;
        private Grid _grid, _innerGrid;
        private StackPanel _stackPanel;
        private Button _apply_Button;
        private IList<TextBox> _textBoxes;
        [OneTimeSetUp]
        public void Setup()
        {
            _window = new TestWindow<GridWindow>();
            _grid = _window.GetUIElements<Grid>().FirstOrDefault();
            _innerGrid = _grid.Children.OfType<Grid>().FirstOrDefault();
            _stackPanel = _window.GetUIElements<StackPanel>().FirstOrDefault();
            _apply_Button = _window.GetUIElements<Button>().FirstOrDefault();
            _textBoxes = _window.GetUIElements<TextBox>().ToList();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _window.Dispose();
        }

        [MonitoredTest("Grid - Should have 3 rows")]
        public void _01_GridShouldHave3Rows()
        {
            AssertGridHas3Cells();
        }

        [MonitoredTest("Grid - First Row should contain a StackPanel")]
        public void _02_FirstRowOfGridShouldContainAStackPanel()
        {
            AssertGridHasHorizontalStackPanelInHisFirstRow();
        }

        [MonitoredTest("Grid - The StackPanel in the first row should contain 2 TextBoxes, 2 TextBlocks and a Button")]
        public void _03_StackPanelShouldContain5Controls()
        {
            UIElementCollection stackPanelChildren = _stackPanel.Children;
            Assert.That(stackPanelChildren.Count, Is.EqualTo(5), "The stackPanel within the first row of the Grid should contain 5 controls.");

            Assert.That(stackPanelChildren.OfType<TextBlock>().Count(), Is.EqualTo(2), "The StackPanel has to contain 2 TextBlocks.");
            Assert.That(stackPanelChildren.OfType<TextBox>().Count(), Is.EqualTo(2), "The StackPanel has to contain 2 TextBoxex.");
            Assert.That(stackPanelChildren.OfType<Button>().Count(), Is.EqualTo(1), "The StackPanel has to contain 1 Button.");

        }

        [MonitoredTest("Grid - Button in StackPanel should a have Click event handler")]
        public void _04_ButtonInStackPanelShouldHaveClickEventHandler()
        {
            Assert.That(HasClickEventHandler(_apply_Button), Is.True, "The button in the StackPanel should have a click event handler.");
        }

        [MonitoredTest("Grid - Inner Grid has 4 rows and 4 columns")]
        public void _05_InnerGridShouldHave4RowsAnd4Columns()
        {
            AssertHasInnerGrid();
            AssertInnerGridHas4RowsAnd4Columns();
        }

        [MonitoredTest("Grid - Inner Grid contains a lightgreen Button")]
        public void _06_InnerGridContainsAButton()
        {
            Assert.That(_innerGrid.Children.OfType<Button>().Count(), Is.EqualTo(1), "Inner Grid should contain a Button");
            Button button = (Button)_innerGrid.Children[0];
            Assert.That((button.Background as SolidColorBrush)?.Color, Is.EqualTo(Colors.LightGreen), "The button should have a LightGreen backColor");
        }

        [MonitoredTest("Grid - The selected button should have a LightGreen BackColor")]
        public void _07_TheSelectedButtonShouldHaveALightGreenBackColor()
        {
            AssertApplyButton();
        }

        private void AssertGridHasHorizontalStackPanelInHisFirstRow()
        {
            Assert.That(_stackPanel, Is.Not.Null, "Outer Grid should contain a StackPanel");
            Assert.That(_stackPanel.GetValue(Grid.RowProperty), Is.EqualTo(0), "Grid should contain a StackPanel in its first row");
            Assert.That(_stackPanel.Orientation, Is.EqualTo(Orientation.Horizontal), "The stackpanel inside the first row of the grid must have an horizontal orientation");
        }

        private void AssertApplyButton()
        {
            Random random = new Random();
            int x = random.Next(0, 4);
            int y = random.Next(0, 4);
            _textBoxes[0].Text = x.ToString();
            _textBoxes[1].Text = y.ToString();
            _apply_Button.FireClickEvent();
            DispatcherUtil.DoEvents();

            int rowValue = Convert.ToInt32(_textBoxes[0].Text);
            int colValue = Convert.ToInt32(_textBoxes[1].Text);
            _apply_Button = _window.GetUIElements<Button>().FirstOrDefault();

            Button content = (Button)_innerGrid.Children
            .Cast<UIElement>()
            .FirstOrDefault(e => Grid.GetRow(e) == rowValue && Grid.GetColumn(e) == colValue);

            Assert.That(content, Is.Not.Null, $"Cannot find a Button in grid cell ({rowValue}, {colValue}).");
            Assert.That((content.Background as SolidColorBrush)?.Color, Is.EqualTo(Colors.LightGreen), "The Background of the selected cell has to be lightgreen.");
            Assert.That(content.Content, Is.EqualTo($"Row {rowValue}, Column {colValue}"), "The content of the cell isn't correct");
        }

        private bool HasClickEventHandler(object objectWithEvent)
        {
            object eventStore = objectWithEvent.GetType()
                .GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(objectWithEvent, null);

            if (eventStore != null)
            {
                RoutedEventHandlerInfo clickEvent = ((RoutedEventHandlerInfo[])eventStore
                        .GetType()
                        .GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                        .Invoke(eventStore, new object[] { Button.ClickEvent }))
                    .FirstOrDefault();

                if (clickEvent == default) return false;
                return clickEvent.Handler?.Method.Name != null;
            }
            return false;
        }


        private void AssertGridHas3Cells()
        {
            AssertHasOuterGrid();

            Assert.That(_grid.RowDefinitions, Has.Count.EqualTo(3), () => "The 'Grid' should have 3 rows defined.");

            Assert.That(_grid.RowDefinitions[0].Height.IsAuto, Is.True, "The first row of the outer grid should adjust to the height of its children.");
            Assert.That(_grid.RowDefinitions[1].Height.Value, Is.EqualTo(20), "The second row (empty row) of the outer grid should be set to 20.");
            Assert.That(_grid.RowDefinitions[2].Height.IsStar, Is.True, "The third row of the outer grid should be a star.");
            Assert.That(_grid.ColumnDefinitions, Has.Count.EqualTo(0), () => "The 'Grid' should have no columns defined.");
        }

        private void AssertHasOuterGrid()
        {
            Assert.That(_grid, Is.Not.Null, "No 'Grid' could be found.");
            Assert.That(_grid.Parent, Is.SameAs(_window.Window),
                "The 'Grid' should be the child control of the 'Window'.");
        }

        private void AssertHasInnerGrid()
        {
            Assert.That(_innerGrid, Is.Not.Null, "No inner 'Grid' could be found.");
            Assert.That(_innerGrid.Parent, Is.SameAs(_grid),
                "The 'inner Grid' should be the child control of the outer 'Grid'.");
        }

        private void AssertInnerGridHas4RowsAnd4Columns()
        {
            AssertHasInnerGrid();

            Assert.That(_innerGrid.RowDefinitions, Has.Count.EqualTo(4), () => "The 'Grid' should have 4 rows defined.");
            Assert.That(_innerGrid.ColumnDefinitions, Has.Count.EqualTo(4), () => "The 'Grid' should have 4 columns defined.");
        }
    }
}
