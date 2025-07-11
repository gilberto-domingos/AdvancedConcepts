﻿using System.ComponentModel;
namespace NETInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    class Document : IStorable, INotifyPropertyChanged
    {
        private string name;
        private Boolean mNeedsSave = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropChange(string PropName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }

        public Document(string s) {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public string DocName {
            get { return name; }
            set { 
                name = value;
                NotifyPropChange("DocName");
            }
        }

        public void Save() {
            Console.WriteLine("Saving the document");
        }

        public void Load() {
            Console.WriteLine("Loading the document");
        }

        public Boolean NeedsSave {
            get { return mNeedsSave; }
            set { 
                mNeedsSave = value;
                NotifyPropChange("NeedsSave");
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            d.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine($"Document property changed: {e.PropertyName}");
            };
            
            d.DocName = "My Document";
            d.NeedsSave = true;
        }
    }
}
