using System;
using System.Collections.Generic;
using System.Text;

namespace CBTree
{
    class Person
    {
        public string FirstName;
        public string LastName;
        public string SSN;

        private static Random rand = new Random();
        private static string[] last_names = {"Agg", "Albright", "Armitage", "Arthur", "Aultman", "Baumgartner", "Bennett", "Blackburn", "Blunt", "Bryan", "Buck", "Buehler", "Buttermore", "Campbell", "Carmichael", "Congdon", "Coughenour", "Demuth", "Diller", "Eastwood", "Eisenman", "Emrick", "Ewing", "Finlay", "Focell", "Gilman", "Goodman", "Grant", "Gronko", "Hair", "Hamilton", "Hanford", "Harden", "Harrow", "Hayhurst", "Haynes", "Herndon", "Hice", "Holdsworth", "Hozier", "Hynes", "Jardine", "Jones", "Joyce", "Jyllian", "Keister", "Kiefer", "Laborde", "Ling", "Loewentsein", "Mccallum", "Mcintosh", "Millhouse", "Minnie", "Mitchell", "Mosser", "Myers", "Nabholz", "Newlove", "Nicholas", "Noton", "Orbell", "Osterwise", "Owens", "Patterson", "Pinney", "Powers", "Reichard", "Roberts", "Roby", "Rose", "Rumbaugh", "Schmidt", "Schneider", "Scott", "Sealis", "Shupe", "Spring", "Stahl", "Stone", "Stroble", "Summy", "Thompson", "Thorley", "Throckmorton", "Toke", "Tomco", "Turzanski", "Vorrasi", "Wallace", "Welty", "White", "Wible", "Wilkins", "Wilkinson", "Wortman", "Young", "Zadovsky", "Zeal", "Zoucks"};
        private static string[] first_names = {"Adam", "Adelaide", "Alexander", "Aline", "Alys", "Amilia", "Annie", "Arabella", "Arlette", "Audrea", "Benedict", "Briana", "Brook", "Bryant", "Bud", "Carita", "Cassie", "Chaz", "Cherie", "Christa", "Christian", "Clint", "Cooper", "Corine", "Daren", "Della", "Dinah", "Earnestine", "Eleonor", "Elisa", "Eliza", "Elizabeth", "Emely", "Emmaline", "Emmy", "Ethan", "Evangelina", "Farley", "Forest", "Garnette", "Garrick", "Godiva", "Greta", "Hammond", "Haydee", "Hugh", "Ivy", "Jamaar", "Janene", "Jared", "Jayne", "Joan", "Jonathan", "Juliana", "Katelin", "Kimberley", "Krystle", "Lacy", "Lauressa", "Lenora", "Lettie", "Letty", "Lilac", "Lorrin", "Madalyn", "Madelyn", "Margo", "Marlowe", "Mary", "Mason", "Merlin", "Micah", "Mora", "Nicodemus", "Nita", "Quin", "Rayna", "Reina", "Roberta", "Rodge", "Rodney", "Rowina", "Ruth", "Sallie", "Savannah", "Sibilla", "Skye", "Sterling", "Tad", "Tanisha", "Tansy", "Tatton", "Theo", "Theodore", "Tresha", "Valentine", "Vergil", "Verity", "Willoughby", "Zackery"};

        public Person(string new_ssn, string new_firstname, string new_lastname)
        {
            SSN = new_ssn;
            FirstName = new_firstname;
            LastName = new_lastname;
        }

        // Generate a random Person.
        public Person()
        {
            FirstName = first_names[rand.Next(0, first_names.Length)];
            LastName = last_names[rand.Next(0, last_names.Length)];
            SSN =
                rand.Next(0, 1000).ToString("000") + "-" +
                rand.Next(0, 100).ToString("00") + "-" +
                rand.Next(0, 10000).ToString("0000");
        }

        public override string ToString()
        {
            return SSN + ": " + FirstName + " " + LastName;
        }
    }
}
