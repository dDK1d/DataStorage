using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace DataStorage;

public partial class AddUserPage : ContentPage
{

    private ObservableCollection<User> users; 
    private User newUser;
    public AddUserPage(ObservableCollection<User> users)
    {
        InitializeComponent();
        this.users = users;
        newUser = new User();
    }

    private async void btn_SelectPhoto_Clicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Выберите фотографию" });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            userPhoto.Source = ImageSource.FromStream(() => stream);
            newUser.PhotoPath = result.FullPath; 
        }
        else
        {
            userPhoto.Source = "default_photo.jpg"; 
            newUser.PhotoPath = "default_photo.jpg"; 
        }
    }

    private void btn_Save_Clicked(object sender, EventArgs e)
    {
        string fullNameInput = fullNameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(fullNameInput)) 
        {
            fullNameEntry.BackgroundColor = Colors.LightCoral;
            DisplayAlert("Ошибка", "Пожалуйста, введите ФИО.", "OK");
            return;
        }
        else
        {
            fullNameEntry.BackgroundColor = Colors.White;
        }

        fullNameInput = System.Text.RegularExpressions.Regex.Replace(fullNameInput, @"\s+", " ");
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        fullNameInput = textInfo.ToTitleCase(fullNameInput.ToLower());

        if (!System.Text.RegularExpressions.Regex.IsMatch(fullNameInput, @"^[А-ЯЁа-яёA-Za-z\s]+$"))
        {
            DisplayAlert("Ошибка", "ФИО может содержать только буквы и пробелы.", "OK");
            return;
        }

        newUser.FullName = fullNameInput;
        newUser.Gender = genderPicker.SelectedItem?.ToString();


        if (genderPicker.SelectedItem == null)
        {
            DisplayAlert("Ошибка", "Пожалуйста, выберите пол.", "OK");
            return;
        }


        if (int.TryParse(ageEntry.Text, out int age))
        {
            if (age < 15 || age > 50)
            {
                ageEntry.TextColor = Colors.LightCoral;
                DisplayAlert("Ошибка", "Возраст должен быть в диапазоне от 15 до 50.", "OK");
                return;
            }
            ageEntry.TextColor = Colors.LightGreen;
            newUser.Age = age;
        }
        else
        {
            ageEntry.TextColor = Colors.LightCoral;
            DisplayAlert("Ошибка", "Пожалуйста, введите корректный возраст.", "OK");
            return;
        }

        newUser.NeedsDorm = dormSwitch.IsToggled;
        newUser.IsLeader = leaderSwitch.IsToggled;
        newUser.Grade = (int)gradeSlider.Value;

        if (string.IsNullOrEmpty(newUser.PhotoPath))
        {
            newUser.PhotoPath = "default_photo.png";
        }

        users.Add(newUser);
        Navigation.PopAsync();
    }

    private void Sw_DormSwitch(object sender, ToggledEventArgs e)
    {
        dormSwitchLabel.Text = e.Value ? "Да" : "Нет";
    }

    private void Sw_LeaderSwitch(object sender, ToggledEventArgs e)
    {
        leaderSwitchLabel.Text = e.Value ? "Да" : "Нет";
    }
    private void SliderValue_Changed(object sender, ValueChangedEventArgs e)
    {
        int roundedValue = (int)Math.Round(e.NewValue);
        gradeLabel.Text = $"Оценка: {roundedValue}";    
        gradeSlider.Value = roundedValue;
    }
}
