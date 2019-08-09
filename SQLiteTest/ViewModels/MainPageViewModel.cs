using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteTest
{
    public class MainPageViewModel// : INotifyPropertyChanged
    {
        public string EntryData { get; set; }
        public ICommand addData { get; set; }
        public ObservableCollection<DataModel> DataList { get; set; } = new ObservableCollection<DataModel>();

        public MainPageViewModel()
        {
            addData = new Command(AddDataToList);
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public void AddDataToList()
        {
            DataList.Add(new DataModel
            {
                DataText = EntryData
            });
            EntryData = "";
            //PropertyChanged(this, new PropertyChangedEventArgs("DataList"));
        }

        public class DataModel
        {
            public string DataText { get; set; }
        }
    }
}
