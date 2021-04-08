using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassesAndInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //valueVsReferenceTypes();
            //classesAndObjects();
            //classExamples();
            //templateMethodExample();
            //ienumerableExample();
            //cardstuff();
            genericsStuff();
            Console.ReadLine();
        }

        #region Variable stuff

        private static void valueVsReferenceTypes()
        {
            int x = 3;  //000000...11
            int y = 3;
            bool result = (x == y);
            Console.WriteLine($"x == y: {result}");

            x = 4;  //0000000...100
            result = (x == y);
            Console.WriteLine($"x (changed) == y: {result}");

            MyNumber number1 = new MyNumber() { Value = 3 };
            MyNumber number2 = new MyNumber() { Value = 3 };
            result = (number1.Value == number2.Value);
            Console.WriteLine($"number1.Value == number2.Value: {result}");

            result = (number1 == number2);
            Console.WriteLine($"number1 == number2: {result}");

            MyNumber number3 = new MyNumber() { Value = 3 };
            MyNumber number4 = number3;
            result = (number3 == number4);
            Console.WriteLine($"number3 == number4: {result}");

            number3.Value = 4;
            result = (number3 == number4);
            Console.WriteLine($"Again, number3 == number4: {result}");

            number3 = new MyNumber() { Value = 4 };
            result = (number3 == number4);
            Console.WriteLine($"Yet again, number3 == number4: {result}");

            result = (number3.Value == number4.Value);
            Console.WriteLine($"number3.Value == number4.Value: {result}");

            // Value types (abridged): bool, int, char, enum long, decimal
            // Reference types: array, string, class, delegate

            //// Parameter passing

            int intof3 = 3;
            var intresult = addOneToInt(intof3);
            result = intresult == intof3;
            Console.WriteLine($"result = {result}, intresult = {intresult}, intof3 = {intof3}");

            MyNumber numberof3 = new MyNumber() { Value = 3 };
            int numberresult = addOneToClassInstance(numberof3);
            result = numberresult == numberof3.Value;
            Console.WriteLine($"result = {result}, numberresult = {numberresult}, numberof3.Value = {numberof3.Value}");

            intof3 = 3;
            intresult = addOneToIntByRef(ref intof3);
            result = intresult == intof3;
            Console.WriteLine($"result = {result}, intresult = {intresult}, intof3 = {intof3}");




            //// Immutable types

            //string startOfAlphabet = "abc";
            //string alphabetresult = addEndOfAlphabet(startOfAlphabet);
            //Console.WriteLine($"alphabetresult = {alphabetresult}, startofAlphabet = {startOfAlphabet}");
            //// Also DateTime, TimeSpan, Uri, Tuple and others

            //// Nulls and un-assigned values

            ////int a = null;   // Not allowed
            //MyNumber b = null;  // This is ok, why?  Note would try and avoid this in real life due to error below
            ////Console.WriteLine($"Value of b.Value = {b.Value}");     // This will cause runtime error;
            //b = new MyNumber();
            //Console.WriteLine($"Value of b.Value = {b.Value}");

            //// For value types can use nullable wrappers
            //int? c = null;
            //Console.WriteLine($"Value of c = {c}");
            ////Console.WriteLine($"Value of c.Value = {c.Value}");     // Like example above this will cause runtime error

            //// is equivalent to
            //Nullable<int> d = null;
            //// is equivalent to
            //Nullable<int> e = new Nullable<int>();
            //Console.WriteLine($"Value of d = {d}");
            //Console.WriteLine($"Value of e = {e}");
            ////Console.WriteLine($"Value of d.Value = {d.Value}");     // Again will throw runtime error
            ////Console.WriteLine($"Value of e.Value = {e.Value}");     // Again will throw runtime error
        }

        private static int addOneToInt(int number)
        {
            number = number + 1;
            return number;
        }

        private static int addOneToClassInstance(MyNumber number)
        {
            number.Value = number.Value + 1;
            return number.Value;
        }

        private static int addOneToIntByRef(ref int number)
        {
            number = number + 1;
            return number;
        }

        private static string addEndOfAlphabet(string value)
        {
            value = value + "xyz";
            return value;
        }

        #endregion

        #region Class stuff

        private static void classesAndObjects()
        {
            // All classes descend from object
            var x = new object();
            Console.WriteLine($"Type of x {x.GetType()}");
            Console.WriteLine($"x is object {x is object}");

            var number = new MyNumber() { Value = 3 };
            Console.WriteLine($"Type of number {number.GetType()}");
            Console.WriteLine($"number is object {number is object}");
            // Note even though didn't explcitly declare MyNumber as inheriting from object it's inferred

            // Casting, can cast to any ancestor type in the inheritance 
            object numberasobject = (object)number;
            Console.WriteLine($"Type of numberasobject {numberasobject.GetType()}");
            Console.WriteLine($"numberasobject is object {numberasobject is object}");
            // So casting doesn't create a new object

            // If we have the following OO classes Animal -> Cat : Animal (i.e. Cat inherits from Animal)
            // Various language can be used, such as:
            //
            // Animal is the supertype Cat is the sub type
            // Cat inherits from Animal
            // Cat extends Animal
            // Animal is the parent of Cat
            // Animal is the base pof Cat
            //
            // When casting we can only cast up the chain i.e. from a subtype to a supertype
        }

        private static void classExamples()
        {
            //var x = new ExampleClass();
            //var y = new object();
            //Console.WriteLine($"{x.ToString()} is of type {x.GetType()}");
            //Console.WriteLine($"{y.ToString()} is of type {y.GetType()}");

            //var z = new InheritedClass();
            //Console.WriteLine($"Value is {z.MyProperty}");
            //z.AddOneToMyProperty();
            //Console.WriteLine($"Value is {z.MyProperty}");

            var sender = new LegalFriendlyEmail();
            sender.SendEmail("Chris Clark");
        }

        #endregion

        #region Template method stuff

        private static void templateMethodExample()
        {
            var email = new NewFeatureEmail();
            email.To = "jack.gittoes@nhs.net";
            sendTheMail(email);

            var email2 = new NewOrganisationEmail("ABC123", "Aplhabet Company");
            sendTheMail(email2, "chris.clark@nhs.net");

            var email3 = new YetAnotherEmail();
            sendTheMail(email3, "chris.clark@nhs.net");
        }

        private static void sendTheMail(IEmailer emailer, string to = null)
        {
            // Store a record of date time and who sent email
            Console.WriteLine($"Sending email at {DateTime.Now}");

            if (!string.IsNullOrWhiteSpace(to))
            {
                emailer.SendEmail(to);
            }
            else
            {
                emailer.SendEmail();
            }

            // Store a record of who the email was sent to
            Console.Write($"The email was sent to: {emailer.To}");
        }

        #endregion

        #region IEnumerable stuff

        private static void ienumerableExample()
        {
            var x = new Card(1);
            var y = new Card(52);
            var z = new Card(13);
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);
        }

        private static void cardstuff()
        {
            // Initialise cards
            var pack = new PackOfCards();

            // Each player gets 13 cards
            var player1Hand = new Card[13];
            var player2Hand = new Card[13];
            var player3Hand = new Card[13];
            var player4Hand = new Card[13];
            var playerNo = 1;
            var cardno = 0;

            foreach (Card card in pack.Shuffle())
            {
                switch (playerNo)
                {
                    case 1:
                        player1Hand[cardno] = card;
                        break;
                    case 2:
                        player2Hand[cardno] = card;
                        break;
                    case 3:
                        player3Hand[cardno] = card;
                        break;
                    default:
                        player4Hand[cardno] = card;
                        break;
                }

                playerNo = playerNo + 1;

                if (playerNo > 4)
                {
                    cardno++;
                    playerNo = 1;
                }
            }

            Console.WriteLine("Player One's Hand:");

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine(player1Hand[i].ToString());
            }

        }

        #endregion

        private static void genericsStuff()
        {
            var col1 = new List<Point>();
            col1.Add(new Point() { XValue = 10, YValue = 20 });
            col1.Add(new Point() { XValue = 11, YValue = 201 });

            foreach (var p in col1)
            {
                Console.WriteLine($"XValue is {p.XValue}, YValue is {p.YValue}");
            }

            var col2 = new PointCollection();
            col2.Add(new Point() { XValue = 10, YValue = 20 });
            col2.Add(new Point() { XValue = 11, YValue = 201 });

            foreach (Point p in col2)
            {
                Console.WriteLine($"XValue is {p.XValue}, YValue is {p.YValue}");
            }

            var people = new List<Person>()
            {
                new Person() { Id = 1, Name = "Chris Clark" },
                new Person() { Id = 2, Name = "Mark Gummow" },
                new Person() { Id = 3, Name = "Jack Gittoes" },
            };

            var getter = new MyGetterClass();
            var chosenOne = getter.FindById(people, 2);
            Console.WriteLine($"Chosen person: {chosenOne.Name}");
            chosenOne = getter.FindByName(people, "chris clark");
            Console.WriteLine($"Id for chris clark is {chosenOne.Id}");

            var depts = new List<Department>()
            {
                new Department() { Id = 1, Subject = "Chemistry", NoOfStudents = 2 },
                new Department() { Id = 2, Subject = "Art History", NoOfStudents = 15 },
                new Department() { Id = 3, Subject = "Music", NoOfStudents = 22 }
            };

            var chosenDept = getter.FindById(depts, 2);
            Console.WriteLine($"Chosen department: {chosenDept.Subject}, No of students = {chosenDept.NoOfStudents}");

            var subjects = new List<Subject>()
            {
                new Subject() { Name = "Chemistry" },
                new Subject() { Name = "Art History" },
                new Subject() { Name = "Music", Description = "Everything about notes and stuff" }
            };

            var chosenSubject = getter.FindByName(subjects, "Music");
            Console.WriteLine($"Chosen subject: {chosenSubject.Name}");
            Console.WriteLine(chosenSubject.Description);
        }
    }
}
