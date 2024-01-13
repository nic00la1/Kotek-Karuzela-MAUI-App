namespace Kotek
{
    public partial class MainPage : ContentPage
    {
        private string[] images = { "kot1.jpg", "kot2.jpg", "kot3.jpg", "kot4.jpg" };
        private int currentIndex = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PrevImage(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = images.Length - 1;
            }
            UpdateImageSource();
        }

        private void NextImage(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= images.Length)
            {
                currentIndex = 0;
            }
            UpdateImageSource();
        }

        private void UpdateImageSource()
        {
            string imagePath = images[currentIndex];
            image.Source = imagePath;
        }

        private void UpdateImageFromText()
        {
            if (int.TryParse(ImageNumber.Text, out int imageNumber))
            {
                if (imageNumber >= 1 && imageNumber <= images.Length)
                {
                    currentIndex = imageNumber - 1;
                    UpdateImageSource();
                }
            }
        }

        private void ThemeChange_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                // Change the background color to blue
                this.BackgroundColor = Color.FromRgb(0, 0, 255);
            }
            else
            {
                // Change the background color back to green
                this.BackgroundColor = Color.FromRgb(0, 128, 0); // Green color
            }
        }

        private void NumericEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

            if (e.NewTextValue != newText)
            {
                ImageNumber.Text = newText;
            }
            UpdateImageFromText();
        }
    }
}