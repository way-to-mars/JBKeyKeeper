using System.Collections.Generic;
using System.Windows;
using System.Text.Json;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;


namespace JBKeyKeeper
{
    public partial class App : Application
    {

        private JBKKContainer _JbbkContainer;

        public static JBKKContainer getJBBK() => (Application.Current as App)._JbbkContainer;
        

        public App() { Startup += new StartupEventHandler(OnAppStart); }

        void OnAppStart(object sender, StartupEventArgs e)
        {

            JBKKContainer jbbk = new JBKKContainer
            {
                Name = "Thomas passwords",
                Items = new List<JBBKItem> {
                    new JBBKItem{
                       // Date = "02.02.2023",
                        Name = "Bank account",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "login", Value = "Thomas"},
                            new JBBKPair{ Name = "password", Value = "1234567890"},
                            new JBBKPair{ Name = "Description", Value = "Don't tell anyone"},
                        }
                    },
                    new JBBKItem{
                        //Date = "12.09.2023",
                        Name = "Bank account2",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "login", Value = "Thomas"},
                            new JBBKPair{ Name = "password", Value = "01231230"},
                            new JBBKPair{ Name = "Description", Value = "new password"},
                        }
                    },
                    new JBBKItem{
                        //Date = "12.09.2023",
                        Name = "Some Other Data",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "password", Value = "t7t7t7t7"},
                        }
                    },
                    new JBBKItem{
                        //Date = "12.09.2023",
                        Name = "A lot of data",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "A", Value = "1"},
                            new JBBKPair{ Name = "B", Value = "can you feel my heart?"},
                            new JBBKPair{ Name = "C", Value = "C#"},
                            new JBBKPair{ Name = "D", Value = "When we was young the future was so bright"},
                            new JBBKPair{ Name = "E", Value = "a value"},
                            new JBBKPair{ Name = "F", Value = "This song is a textbook example of good songwritting. Every 4 measures the storytelling from the lyrics goes deeper and deeper, avoids sounding redundant and keeps adding tension for the chorus to be expected and it hits just on time so the message from it hits harder each time and the melodic elements like the bass line, the guitar solos and riffs are simple and effective, very well implemented."},
                        }
                    }

                }
            };

            this._JbbkContainer = jbbk;

            var jbbkSerialized = JsonSerializer.Serialize(jbbk.Seal(),
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                });

            Console.WriteLine("\n" + jbbkSerialized.ToString() + "\n");

            JBKKContainerSealed jbkkFromfile = JsonSerializer.Deserialize<JBKKContainerSealed>(jbbkSerialized);
            JBKKContainer unsealed = jbkkFromfile.Unseal();

            //this.Shutdown();
        }

        public void CloseApp() { this.Shutdown(); }
    }
}
