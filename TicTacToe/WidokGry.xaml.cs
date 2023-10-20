namespace TicTacToe;

public partial class WidokGry : ContentPage
{
    private  ZasadyGry gameRules;
    public Button[] tableButton = new Button[9];
    private string difficultyLevel;
    public char[,] GetGameStatus
    {
        get { return gameRules.GetGameStatus; }
    }
    public WidokGry(string selectedDifficultyLevel)
	{
		InitializeComponent();
        gameRules = new ZasadyGry();
        CollectButtons();
        cos();
        XorO();
        char playerChar = gameRules.GetCurrentPlayer();
        playerCharLabel.Text = "You have an: " + playerChar;
        difficultyLevel = selectedDifficultyLevel;
        difficultyLevelLabel.Text = "Difficulty level: " + difficultyLevel;

    }
    private void button_Clicked(object sender, EventArgs e)
	{
        char currentPlayer = gameRules.GetCurrentPlayer();

        if (currentPlayer == 'X')
        {
            ((Button)sender).Text = "X";
        }
        else
        {
            ((Button)sender).Text = "O";
        }
        int buttonIndex = Array.IndexOf(tableButton, (Button)sender);
        int row = buttonIndex / 3;
        int col = buttonIndex % 3;
        gameRules.UpdateGameTable(row, col);

        if (gameRules.GetWinner())
        {
            Navigation.PushAsync(new WidokWygrana("Player"));
        }
        else if (gameRules.IsBoardFull())
        {
            Navigation.PushAsync(new WidokRemis());
        }
        else 
        {
            if (difficultyLevel == "Easy")
            {
                gameRules.MakeComputerMoveEasy();
            }
            else if (difficultyLevel == "Medium")
            {
                gameRules.MakeComputerMoveMedium();
            }
            else if (difficultyLevel == "Hard")
            {
                gameRules.MakeComputerMoveHard();
            }

            cos();
            if (gameRules.GetWinner())
            {
                Navigation.PushAsync(new WidokWygrana("Computer"));
            }
        }
    }
    private void XorO()
    {
        gameRules.XorO();
    }

    void CollectButtons()
    {
        tableButton[0] = button00;
        tableButton[1] = button01;
        tableButton[2] = button02;
        tableButton[3] = button10;
        tableButton[4] = button11;
        tableButton[5] = button12;
        tableButton[6] = button20;
        tableButton[7] = button21;
        tableButton[8] = button22;

    }
    void cos()
    {
        char[,] tableObject = gameRules.GetGameStatus;
        int indeksTableButton = 0;
        for (int i = 0; i < tableObject.GetLength(0); i++)
        {
            for (int j = 0; j < tableObject.GetLength(1); j++)
            {
                if (tableObject[i, j] == '\0')
                    tableButton[indeksTableButton].Text = String.Empty;
                else
                {
                    tableButton[indeksTableButton].Text = tableObject[i, j].ToString();
                }
                indeksTableButton++;
            }
        }
    }
}