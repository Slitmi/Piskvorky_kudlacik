using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
        }

        private int currentPlayer = 1; // 1 = X, 2 = O, 3 = Y
        private int[,] board = new int[size, size]; // 0 = empty, 1 = X, 2 = O, 3 = Y

        // Edit there values to change the properties of the game
        private static int size = 10;
        private static int numberOfPlays = 0;
        private static int maxNumberOfPlays = size * size;
        private static int neededToWin = 3;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            if (board[row, column] == 0)
            {
                board[row, column] = currentPlayer;

                switch (currentPlayer)
                {
                    case 1:
                        button.Content = "X";
                        break;
                    case 2:
                        button.Content = "O";
                        break;
                    case 3:
                        button.Content = "Y";
                        break;
                }

                numberOfPlays++;
                if (CheckForWinner())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    ResetGame();
                }
                else if (numberOfPlays == maxNumberOfPlays)
                {
                    MessageBox.Show($"Noone's won!");
                    ResetGame();
                }
                else
                {
                    currentPlayer++;

                    if (currentPlayer == 4)
                    {
                        currentPlayer = 1;
                    }

                    switch (currentPlayer)
                    {
                        case 1:
                            playing.Text = "Playing: X";
                            break;
                        case 2:
                            playing.Text = "Playing: O";
                            break;
                        case 3:
                            playing.Text = "Playing: Y";
                            break;
                    }
                }
            }
        }

        private bool CheckForWinner()
        {
            int streak = 0;

            // Horizontal lines (-)
            for (int x = 0; x < size; x++)
            {
                streak = 0;
                for (int y = 0; y < size; y++)
                {
                    if (board[x, y] == currentPlayer)
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }

                    if (streak == neededToWin)
                    {
                        return true;
                    }
                }
            }

            // Vertical lines (|)
            for (int x = 0; x < size; x++)
            {
                streak = 0;
                for (int y = 0; y < size; y++)
                {
                    if (board[y, x] == currentPlayer)
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }

                    if (streak == neededToWin)
                    {
                        return true;
                    }
                }
            }

            // Diagonals left bottom to right top (/)
            for (int i = 0; i < size; i++)
            {
                streak = 0;
                int x = 0;
                int y = i;

                do
                {
                    if (board[y, x] == currentPlayer) { streak++; }
                    else { streak = 0; }

                    if (streak == neededToWin) { return true; }
                    x++; y--;
                } while (y >= 0);
            }

            // Diagonals left top to right bottom (\)
            for (int i = 0; i < size; i++)
            {
                streak = 0;
                int x = 0;
                int y = i;

                do
                {
                    if (board[y, x] == currentPlayer) { streak++; }
                    else { streak = 0; }

                    if (streak == neededToWin) { return true; }
                    x++; y++;
                } while (y < size);
            }

            return false;
        }

        private void ResetGame()
        {
            board = new int[size, size];
            currentPlayer = 1;
            numberOfPlays = 0;

            gameField.Children.Clear();
            gameField.RowDefinitions.Clear();
            gameField.ColumnDefinitions.Clear();
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < size; i++)
            {
                gameField.RowDefinitions.Add(new RowDefinition());
                gameField.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Button button = new Button();
                    button.FontSize = 800 / (2.5 * size);
                    button.Click += Button_Click;

                    Grid.SetRow(button, x);
                    Grid.SetColumn(button, y);

                    gameField.Children.Add(button);
                }
            }
        }
    }
}