using System;

namespace TicTacToe;

public partial class WidokWygrana : ContentPage
{
    private string gameResult;
    public WidokWygrana(string win)
	{
		InitializeComponent();
        gameResult = win;
        UpdateMessage();
    }

    private void OnPlayAgainButtonClicked(object sender, EventArgs e)
    {
        MainPage mainpage = new MainPage();
        Application.Current.MainPage = new NavigationPage(mainpage);
    }
    private void UpdateMessage()
    {
        string win = gameResult;
        winLabel.Text = win + " won!";
    }
}