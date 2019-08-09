using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SQLiteTest.Models;
using Xamarin.Forms;

namespace SQLiteTest
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string EntryData { get; set; }
        public ICommand addData { get; set; }
        public ObservableCollection<DataModel> DataList { get; set; } = new ObservableCollection<DataModel>();

        public MainPageViewModel()
        {
            addData = new Command(AddDataToList);
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void LoadData()
        {
            List<TextRecordModel> dataList = await App.Database.GetTextRecordsAsync();
            foreach(TextRecordModel record in dataList)
            {
                DataList.Add(new DataModel
                {
                    DataText = record.TextData
                });
            }
        }

        public async void AddDataToList()
        {
            DataList.Add(new DataModel
            {
                DataText = EntryData
            });

            await App.Database.SaveTextRecordAsync(new TextRecordModel{
                TextData = EntryData
            });

            EntryData = "";

            PropertyChanged(this, new PropertyChangedEventArgs("EntryData"));
        }

        public class DataModel
        {
            public string DataText { get; set; }
        }
    }
}
