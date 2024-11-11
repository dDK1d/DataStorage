using System;
using Microsoft.Maui.Controls;

namespace DataStorage;

public partial class UserData : ContentPage
{
	public UserData(User user)
	{
		InitializeComponent();
        fullNameLabel.Text = user.FullName;
        userPhotoImage.Source = user.PhotoPath;
        genderLabel.Text = $"Пол: {user.Gender}";
        ageLabel.Text = $"Возраст: {user.Age}";
        needsDormLabel.Text = $"Нужно общежитие: {(user.NeedsDorm ? "Да" : "Нет")}";
        isLeaderLabel.Text = $"Является старостой: {(user.IsLeader ? "Да" : "Нет")}";
        gradeLabel.Text = $"Оценка: {user.Grade}";
    }
}