using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfLerning.Annotations;
using WpfLerning.Commands;
using WpfLerning.Models.MVVM;

namespace WpfLerning.ViewModels
{
    public class PhoneViewModel :INotifyPropertyChanged
    {
        private Phone _secectedPhone;
        private RelayCommand _addCommand;

        public PhoneViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone() { Company= "Samsung", Price = 1500, Title = "A5"},
                new Phone() {Company = "Asus", Price = 5000, Title = "GS"}
            };
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new RelayCommand(obj =>
                       {
                           Phone phone = new Phone();
                           Phones.Insert(0, phone);
                           SelectedPhone = phone;
                       }));
            }
        }

        public ObservableCollection<Phone> Phones { get; set; }

        public Phone SelectedPhone
        {
            get { return _secectedPhone; }
            set
            {
                _secectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
