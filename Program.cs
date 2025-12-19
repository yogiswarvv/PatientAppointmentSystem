using System;

using System.Collections.Generic;


namespace PatientAppointmentSystem

{

    class Program

    {

        class Appointment

        {

            public string PatientName { get; set; }

            public string DoctorName { get; set; }

            public DateTime Date { get; set; }

            public string Time { get; set; }

        }


        static List<Appointment> appointments = new List<Appointment>();


        static void Main(string[] args)

        {

            bool running = true;

            while (running)

            {

                Console.Clear();

                Console.WriteLine("Patient Appointment System (HCA Healthcare Demo)");

                Console.WriteLine("1. Add Appointment");

                Console.WriteLine("2. View Appointments");

                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");


                string choice = Console.ReadLine();

                switch (choice)

                {

                    case "1":

                        AddAppointment();

                        break;

                    case "2":

                        ViewAppointments();

                        break;

                    case "3":

                        running = false;

                        break;

                    default:

                        Console.WriteLine("Invalid choice. Press any key...");

                        Console.ReadKey();

                        break;

                }

            }

        }


        static void AddAppointment()

        {

            Console.Clear();

            Console.WriteLine("Add New Appointment");

            Console.Write("Patient Name: ");

            string patientName = Console.ReadLine();

            Console.Write("Doctor Name: ");

            string doctorName = Console.ReadLine();

            Console.Write("Date (YYYY-MM-DD): ");

            DateTime date;

            while (!DateTime.TryParse(Console.ReadLine(), out date))

                Console.Write("Invalid date. Try again: ");

            Console.Write("Time (e.g., 10:00 AM): ");

            string time = Console.ReadLine();


            appointments.Add(new Appointment

            {

                PatientName = patientName,

                DoctorName = doctorName,

                Date = date,

                Time = time

            });


            Console.WriteLine("Appointment added! Press any key...");

            Console.ReadKey();

        }


        static void ViewAppointments()

        {

            Console.Clear();

            Console.WriteLine("All Appointments");

            if (appointments.Count == 0)

                Console.WriteLine("No appointments.");

            else

                foreach (var a in appointments)

                    Console.WriteLine($"Patient: {a.PatientName}, Doctor: {a.DoctorName}, Date: {a.Date:yyyy-MM-dd}, Time: {a.Time}");


            Console.WriteLine("Press any key...");

            Console.ReadKey();

        }

    }

}