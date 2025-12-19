using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientAppointmentSystem
{
    class Program
    {
        class Appointment
        {
            public int Id { get; set; }
            public string PatientName { get; set; }
            public string DoctorName { get; set; }
            public DateTime Date { get; set; }
            public string Time { get; set; }
        }

        static List<Appointment> appointments = new List<Appointment>();
        static int nextId = 1;

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
                Console.WriteLine("4. Search Appointments by Patient Name");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

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
                        SearchByPatientName();
                        break;
                    case "5":
                        Console.Write("Are you sure you want to exit? (y/n): ");
                        if (Console.ReadLine().Trim().ToLower() == "y")
                            running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-5.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("\nThank you for using the Patient Appointment System. Goodbye!");
        }

        static void AddAppointment()
        {
            Console.Clear();
            Console.WriteLine("--- Add New Appointment ---");

            Console.Write("Patient Name: ");
            string patientName = Console.ReadLine().Trim();

            Console.Write("Doctor Name: ");
            string doctorName = Console.ReadLine().Trim();

            Console.Write("Date (YYYY-MM-DD): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Invalid date format. Please try again (YYYY-MM-DD): ");
            }

            Console.Write("Time (e.g., 10:00 AM): ");
            string time = Console.ReadLine().Trim();

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
                Console.WriteLine($"{"ID",-4} {"Patient",-25} {"Doctor",-20} {"Date",-12} {"Time",-10}");
                Console.WriteLine(new string('-', 71));

                foreach (var a in appointments)
                {
                    Console.WriteLine($"{a.Id,-4} {a.PatientName,-25} {a.DoctorName,-20} {a.Date:yyyy-MM-dd,-12} {a.Time,-10}");
                }
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        static void DeleteAppointment()
        {
            Console.Clear();
            Console.WriteLine("--- Delete Appointment ---");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments available to delete.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            ViewAppointments();  // Reuse view to show IDs

            Console.Write("\nEnter the ID of the appointment to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var appt = appointments.FirstOrDefault(a => a.Id == id);
                if (appt != null)
                {
                    appointments.Remove(appt);
                    Console.WriteLine("\nAppointment deleted successfully!");
                }
                else
                {
                    Console.WriteLine("\nNo appointment found with that ID.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID entered.");
            }

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }

        static void SearchByPatientName()
        {
            Console.Clear();
            Console.WriteLine("--- Search Appointments by Patient Name ---");

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments available to search.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter patient name (or part of name): ");
            string searchTerm = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("\nSearch term cannot be empty.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            var matches = appointments
                .Where(a => a.PatientName.ToLower().Contains(searchTerm.ToLower()))
                .ToList();

            if (matches.Count == 0)
            {
                Console.WriteLine($"\nNo appointments found containing '{searchTerm}'.");
            }
            else
            {
                Console.WriteLine($"\nFound {matches.Count} matching appointment(s):");
                Console.WriteLine($"{"ID",-4} {"Patient",-25} {"Doctor",-20} {"Date",-12} {"Time",-10}");
                Console.WriteLine(new string('-', 71));

                foreach (var a in matches)
                {
                    Console.WriteLine($"{a.Id,-4} {a.PatientName,-25} {a.DoctorName,-20} {a.Date:yyyy-MM-dd,-12} {a.Time,-10}");
                }
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }
    }
}
