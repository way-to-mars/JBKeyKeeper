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
        public App() { Startup += new StartupEventHandler(OnAppStart); }

        void OnAppStart(object sender, StartupEventArgs e)
        {

            JBKKContainer jbbk = new JBKKContainer
            {
                Format = JBKKContainer.TAG,
                Name = "Thomas passwords",
                History = new List<JBBKItem> {
                    new JBBKItem{
                        Date = "02.02.2023",
                        Name = "Bank account",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "login", Value = "Thomas"},
                            new JBBKPair{ Name = "password", Value = "1234567890"},
                            new JBBKPair{ Name = "Description", Value = "Don't tell anyone"},
                        }
                    },
                    new JBBKItem{
                        Date = "12.09.2023",
                        Name = "Bank account",
                        Fields = new List<JBBKPair> {
                            new JBBKPair{ Name = "login", Value = "Thomas"},
                            new JBBKPair{ Name = "password", Value = "01231230"},
                            new JBBKPair{ Name = "Description", Value = "new password"},
                        }
                    }
                }
            };

            var jbbkSerialized = JsonSerializer.Serialize(jbbk.Seal(),
                new JsonSerializerOptions
                {
                    WriteIndented = false,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                });

            Console.WriteLine("\n" + jbbkSerialized.ToString() + "\n");

            JBKKContainerSealed jbkkFromfile = JsonSerializer.Deserialize<JBKKContainerSealed>(jbbkSerialized);
            JBKKContainer unsealed = jbkkFromfile.Unseal();

            this.Shutdown();
        }

    }
}
