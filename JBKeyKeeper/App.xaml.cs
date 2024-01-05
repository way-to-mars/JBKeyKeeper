using System;
using System.Collections.Generic;
using System.Windows;


namespace JBKeyKeeper
{
    public partial class App : Application
    {
        private JBKKContainer2 _JbkkContainer;

        /// <summary>
        /// Returns a copy of JBKK Container
        /// </summary>
        public static JBKKContainer2 GetJBKK() => (Application.Current as App)._JbkkContainer.AsCopy();        

        public App()
        {
            Startup += new((s, e) =>
            {
                _JbkkContainer = CreateContainer();
                var seria = _JbkkContainer.Serialize(out bool _);
                var unseria = seria.Deserialize(out bool _);
                Console.WriteLine(seria);
                Console.WriteLine(unseria);
            });
        }

        public void CloseApp() => Shutdown();


        public JBKKContainer2 CreateContainer() =>
            new()
            {
                Items = new List<JBKKItem2>
                {
                    new JBKKItem2
                    {
                        Name = "Amerigo",
                        SubItems = new List<JBKKSubItem2>
                        {
                            JBKKSubItem2.Build
                            (
                                "First trip",
                                "www.ru",
                                [
                                    new JBKKPair2{ Name = "Date", Value = "03.05.1784"},
                                    new JBKKPair2{ Name = "Duration", Value = "6 months"},
                                    new JBKKPair2{ Name = "Result", Value = "Nothing"},
                                ]
                            ),
                            JBKKSubItem2.Build
                            (
                                "Second trip",
                                "123",
                                [
                                    new JBKKPair2{ Name = "Date", Value = "12.06.1785"},
                                    new JBKKPair2{ Name = "Duration", Value = "10 months"},
                                    new JBKKPair2{ Name = "Result", Value = "Crushed"},
                                ]
                            ),
                            JBKKSubItem2.Build
                            (
                                "Third trip",
                                "000",
                                [
                                    new JBKKPair2{ Name = "Date", Value = "01.03.1787"},
                                    new JBKKPair2{ Name = "Duration", Value = "12 months"},
                                    new JBKKPair2{ Name = "Result", Value = "Found new lands"},
                                ]
                            )
                        }
                    },
                    new JBKKItem2
                    {
                        Name = "Alex II",
                        SubItems = new List<JBKKSubItem2>
                        {
                            JBKKSubItem2.Build
                            (
                                "Personal",
                                [
                                    new JBKKPair2{ Name = "Born", Value = "4 A.D"},
                                    new JBKKPair2{ Name = "Lifetime", Value = "42 years"},
                                    new JBKKPair2{ Name = "Children", Value = "five or more"},
                                ]
                            ),
                            JBKKSubItem2.Build
                            (
                                "Battles",
                                [
                                    new JBKKPair2{ Name = "Фивы", Value = "Победа"},
                                    new JBKKPair2{ Name = "Эрестополь", Value = "Победа"},
                                    new JBKKPair2{ Name = "Бартолономезы", Value = "Победа"},
                                    new JBKKPair2{ Name = "Зенопричал", Value = "Победа"},
                                    new JBKKPair2{ Name = "Вавилон", Value = "Поражение"},
                                ]
                            ),
                        }
                    },
                    new JBKKItem2
                    {
                        Name = "Alex III",
                        SubItems = new List<JBKKSubItem2>
                        {
                            JBKKSubItem2.Build
                            (
                                "Personal",
                                [
                                    new JBKKPair2{ Name = "Born", Value = "3 A.D"},
                                    new JBKKPair2{ Name = "Lifetime", Value = "39 years"},
                                    new JBKKPair2{ Name = "Children", Value = "one"},
                                ]
                            ),
                            JBKKSubItem2.Build
                            (
                                "Battles",
                                [
                                    new JBKKPair2{ Name = "Фивы", Value = "Победа"},
                                    new JBKKPair2{ Name = "Эрестополь", Value = "Победа"},
                                    new JBKKPair2{ Name = "Бартолономезы", Value = "Победа"},
                                    new JBKKPair2{ Name = "Зенопричал", Value = "Победа"},
                                    new JBKKPair2{ Name = "Вавилон", Value = "Поражение"},
                                ]
                            ),
                        }
                    },
                }
            };
    }
}
