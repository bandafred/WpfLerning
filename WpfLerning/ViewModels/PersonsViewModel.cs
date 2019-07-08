using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfLerning.Annotations;
using WpfLerning.Commands;
using WpfLerning.Models;

namespace WpfLerning.ViewModels
{
    public class PersonsViewModel : DependencyObject
    {
        public string Filtered
        {
            get { return (string)GetValue(FilteredProperty); }
            set { SetValue(FilteredProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Filtered.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilteredProperty =
            DependencyProperty.Register("Filtered", typeof(string), typeof(PersonsViewModel), new PropertyMetadata("", Filtered_Changed));

        private static void Filtered_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PersonsViewModel o)
            {
                o.Persons = PersonModels.GetPersons();
                var list = o.Persons.Where(x => x.LastName.Contains(o.Filtered) || x.FirstName.Contains(o.Filtered))
                    .ToList();
                o.Persons = GetObservableCollection(list);
            }
        }


        private static ObservableCollection<PersonModels> GetObservableCollection(object obj)
        {
            var result = new ObservableCollection<PersonModels>();

            if (obj is List<PersonModels> list)
            {
                foreach (var item in list)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public ObservableCollection<PersonModels> Persons
        {
            get { return (ObservableCollection<PersonModels>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Persons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonsProperty =
            DependencyProperty.Register("Persons", typeof(ObservableCollection<PersonModels>), typeof(PersonsViewModel), new PropertyMetadata(null));

        public PersonsViewModel()
        {
            Persons = PersonModels.GetPersons();
        }

        private bool Filter(object obj)
        {
            var result = true;
            if (obj is PersonModels o)
            {
                if ( !string.IsNullOrWhiteSpace(Filtered) && !o.FirstName.Contains(Filtered) && !o.LastName.Contains(Filtered)) result = false;
            }

            return result;
        }
    }
}
