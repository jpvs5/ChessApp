using Avalonia.Layout;
using Avalonia.Controls;
using ChessApp.Models;
using ChessApp.ViewModels;
using Avalonia.Data;

namespace ChessApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid grid = this.FindControl<Grid>("BoardGrid");

            string[] cols = ["a", "b", "c", "d", "e", "f", "g", "h"];
            string[] rows = ["8", "7", "6", "5", "4", "3", "2", "1"];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < cols.Length; j++)
                {
                    var square = new Button
                    {
                        Name = string.Concat(cols[j], rows[i]),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        
                    };

                    square.CommandParameter = square.Name;

                    string value = string.Concat("Board[", (i * 8 + j).ToString(), "]");

                    square.Bind(Button.CommandProperty, new Binding("SelectSquareCommand"));
                    square.Bind(Button.ContentProperty, new Binding(value));

                    Grid.SetColumn(square, j);
                    Grid.SetRow(square, i);

                    grid.Children.Add(square);
                }
            }
        }
    }
}