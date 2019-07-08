using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLerning.Models
{
    public class PersonModels
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
    }
}
