using System;

using System.Collections.Generic;


namespace PatientAppointmentSystem

{

    class Program

    {

        class Appointment

        {

            public int Id { get; set; } // New: Unique ID for deletion

            public string PatientName { get; set; }

            public string DoctorName { get; set; }

            public DateTime Date { get; set; }

            public string Time { get; set; }

        }


        static List<Appointment> appointments = new List<Appointment>();

        static int nextId = 1; // Auto-incrementing ID


        static void Main(string[] args)

        {

            bool running = true;

            while (running)

            {

                Console.Clear();

                Console.WriteLine("=== Patient Appointment System (HCA Healthcare Demo) ===");

                Console.WriteLine("1. Add Appointment");

                Console.WriteLine("2. View All Appointments");

                Console.WriteLine("3. Delete Appointment");

                Console.WriteLine("4. Exit");

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

                        DeleteAppointment();

                        break;

                    case "4":

                        Console.Write("Are you sure you want to exit? (y/n): ");

                        if (Console.ReadLine().ToLower() == "y")

                            running = false;

                        break;

                    default:

                        Console.WriteLine("Invalid choice. Press any key...");

                        Console.ReadKey();

                        break;

                }

            }


            Console.WriteLine("Thank you for using the system. Goodbye!");

        }


        static void AddAppointment()

        {

            Console.Clear();

            Console.WriteLine("--- Add New Appointment ---");


            Console.Write("Patient Name: ");

            string patientName = Console.ReadLine();


            Console.Write("Doctor Name: ");

            string doctorName = Console.ReadLine();


            Console.Write("Date (YYYY-MM-DD): ");

            DateTime date;

            while (!DateTime.TryParse(Console.ReadLine(), out date))

            {

                Console.Write("Invalid date. Please try again (YYYY-MM-DD): ");

            }


            Console.Write("Time (e.g., 10:00 AM): ");

            string time = Console.ReadLine();


            appointments.Add(new Appointment

            {

                Id = nextId++,

                PatientName = patientName,

                DoctorName = doctorName,

                Date = date,

                Time = time

            });


            Console.WriteLine("\nAppointment successfully added!");

            Console.WriteLine("Press any key to return to main menu...");

            Console.ReadKey();

        }


        static void ViewAppointments()

        {

            Console.Clear();

            Console.WriteLine("--- All Appointments ---");


            if (appointments.Count == 0)

            {

                Console.WriteLine("No appointments scheduled yet.");

            }

            else

            {

                Console.WriteLine($"{"ID",-4} {"Patient",-20} {"Doctor",-20} {"Date",-12} {"Time",-10}");

                Console.WriteLine(new string('-', 66));


                foreach (var a in appointments)

                {

                    Console.WriteLine($"{a.Id,-4} {a.PatientName,-20} {a.DoctorName,-20} {a.Date:yyyy-MM-dd,-12} {a.Time,-10}");

                }

            }


            Console.WriteLine("\nPress any key to return...");

            Console.ReadKey();

        }


        static void DeleteAppointment()

        {

            Console.Clear();

            Console.WriteLine("--- Delete Appointment ---");


            if (appointments.Count == 0)

            {

                Console.WriteLine("No appointments to delete.");

                Console.WriteLine("Press any key to return...");

                Console.ReadKey();

                return;

            }


            ViewAppointments(); // Show list with IDs


            Console.Write("\nEnter the ID of the appointment to delete: ");

            if (int.TryParse(Console.ReadLine(), out int id))

            {

                var appt = appointments.Find(a => a.Id == id);

                if (appt != null)

                {

                    appointments.Remove(appt);

                    Console.WriteLine("\nAppointment deleted successfully!");

                }

                else

                {

                    Console.WriteLine("\nAppointment ID not found.");

                }

            }

            else

            {

                Console.WriteLine("\nInvalid ID entered.");

            }


            Console.WriteLine("Press any key to return...");

            Console.ReadKey();

        }

    }

}
