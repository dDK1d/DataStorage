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
        genderLabel.Text = $"���: {user.Gender}";
        ageLabel.Text = $"�������: {user.Age}";
        needsDormLabel.Text = $"����� ���������: {(user.NeedsDorm ? "��" : "���")}";
        isLeaderLabel.Text = $"�������� ���������: {(user.IsLeader ? "��" : "���")}";
        gradeLabel.Text = $"������: {user.Grade}";
    }
}