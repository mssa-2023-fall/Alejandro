using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExercise
{   public class PersonEventArgs: EventArgs
    {
        public string Name { get; set; }
        public PersonEventArgs(string name)
        {
            Name = name;
        }
    }
    public class Publisher
    {
        public event EventHandler<PersonEventArgs> ContactNotify;
        
        public void CountMessage(List<string> personList)
        {
            Dictionary<string, int> ListofPeople = new Dictionary<string, int>();
            foreach(string person in personList)
            {
                if(!ListofPeople.ContainsKey(person))
                    ListofPeople[person] = 0;
                ListofPeople[person] +=;
                if (ListofPeople[person] == 3)
                    ContactNotify += Publisher_ContactNotify;
            }
        }

        private void Publisher_ContactNotify(object? sender, PersonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public class OnItemAddedEventArgs<T> : EventArgs
        {
            public int CountBeforeAddition { get; set; }
            public int CountAfterAddition { get; set; }
            public T? ItemAdded { get; set; }
            public DateTime InsertionTimestamp { get; set; }
            public int ItemPositionInList { get; set; }
        }


        public delegate void ItemAddedEventDelegate<T>(NoisyList<T> sender, OnItemAddedEventArgs<T> args);


    }
}
