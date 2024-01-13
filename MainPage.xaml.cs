using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kotek
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string[] images = { "kot1.jpg", "kot2.jpg", "kot3.jpg", "kot4.jpg" };
        private int currentIndex = 0;
        private bool isBlueTheme = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            UpdateImageSource();
        }

        public string CurrentImagePath => images[currentIndex];
        public string CurrentImageNumber { get; set; }
        public bool IsBlueTheme
        {
            get => isBlueTheme;
            set
            {
                if (isBlueTheme != value)
                {
                    isBlueTheme = value;
                    OnPropertyChanged();
                    UpdateTheme();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateImageSource()
        {
            OnPropertyChanged(nameof(CurrentImagePath));
        }

        private void UpdateTheme()
        {
            if (IsBlueTheme)
            {
                this.BackgroundColor = Color.FromRgb(0, 0, 255);
            }
            else
            {
                this.BackgroundColor = Color.FromRgb(0, 128, 0); // Zielony kolor
            }
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