using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinCodeGenerators
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            CalculateAgeCommand = new Command<Label>(CalculateAge);
            Name = "David A Morrow";
            Birthdate = new DateTime(2016, 4, 19).ToString("d");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!(object.Equals(field, newValue)))
            {
                field = (newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string name;

        public string Name
        { 
            get => name; 
            set => SetProperty(ref name, value);
            
        }

        private string birthdate;

        public string Birthdate { get => birthdate; set => SetProperty(ref birthdate, value); }

        private Command calculateAgeCommand;

        public Command<Label> CalculateAgeCommand { get; }
       

        private void CalculateAge(object obj)
        {
            var label = obj as Label;
            label.Text = "Hello From Xamarin ViewModel";
        }
    }
}