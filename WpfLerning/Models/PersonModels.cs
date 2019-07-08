using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfLerning.Annotations;

namespace WpfLerning.Models
{
    public class PersonModels : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static ObservableCollection<PersonModels> GetPersons()
        {
            var result = new ObservableCollection<PersonModels>();

            result.Add(new PersonModels { LastName = "Иванов", FirstName = "Иван" });
            result.Add(new PersonModels { LastName = "Петров", FirstName = "Петр" });
            result.Add(new PersonModels { LastName = "Сидоров", FirstName = "Сидр" });

            return result;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
