namespace TicTacToe;

public partial class WidokRemis : ContentPage
{
	public WidokRemis()
	{
		InitializeComponent();
	}
    private void OnPlayAgainButtonClicked(object sender, EventArgs e)
    {
        MainPage mainpage = new MainPage();
        Application.Current.MainPage = new NavigationPage(mainpage);
    }
}