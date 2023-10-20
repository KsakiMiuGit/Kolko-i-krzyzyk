namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            string difficultyLevel = "";

            if (easyRadioButton.IsChecked)
            {
                difficultyLevel = "Easy";
            }
            else if (mediumRadioButton.IsChecked)
            {
                difficultyLevel = "Medium";
            }
            else if (hardRadioButton.IsChecked)
            {
                difficultyLevel = "Hard";
            }

            await Navigation.PushAsync(new WidokGry(difficultyLevel));
        }
    }
}