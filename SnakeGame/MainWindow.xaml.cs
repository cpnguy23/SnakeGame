using System.Windows;
using System.Windows.Controls;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int rows = 15, cols = 15;                  // two variables for rows and columns
        private readonly Image[,] gridImages;                       //2d image array for image controls, helps access image for a given position
        
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetUpGrid();
        }

        private Image[,] SetUpGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;                           /* gamegrid == mainwindow.xaml */
            GameGrid.Columns = cols;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty
                    };


                }

            }

            return images;
        }
    }
}
