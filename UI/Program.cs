using System;
using System.Collections.Generic;
using Elysium;
using ElysiumBusinessServices;
using MimeKit;
using MailKit.Net.Smtp;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransactionServices transactionServices = new TransactionServices();
            GetServices getServices = new GetServices();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nWelcome to Elysium! The Best Internet Cafe in the South!");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. View Remaining Balance");
                Console.WriteLine("3. Store Info");
                Console.WriteLine("4. Exit");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CreateAccount(transactionServices);
                        break;
                    case 2:
                        ViewBalance(getServices);
                        break;
                    case 3:
                        ShowStoreInfo();
                        break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Thank you for visiting Elysium Internet Cafe! Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again. :(");
                        break;
                }
            }
        }

        static void CreateAccount(TransactionServices transactionServices)
        {
            Console.WriteLine("Enter a username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

        
            string balance = "Juno";

            User newUser = new User
            {
                username = username,
                password = password,
                email = email,
                balance = balance
            };

            if (transactionServices.CreateUser(newUser))
            {
                SendWelcomeEmail(newUser);
                Console.WriteLine("Account created successfully and welcome email sent.");
            }
            else
            {
                Console.WriteLine("Failed to create account. Username might already exist.");
            }
        }

        static void ViewBalance(GetServices getServices)
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            User foundUser = getServices.GetUser(username);
            if (foundUser != null)
            {
                Console.WriteLine($"Username: {foundUser.username}");
                Console.WriteLine($"Remaining Balance: {foundUser.balance}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void ShowStoreInfo()
        {
            Console.WriteLine("\nStore Info:");
            Console.WriteLine("Store Opening - 24/7 365");
            Console.WriteLine("Store Address - Block 5 Lot 7 Ruby St. Pacita 1A San Pedro, Laguna");
            Console.WriteLine("\nCredit System:");
            Console.WriteLine("Juno - 1 Hour");
            Console.WriteLine("Deus - 2 Hours");
            Console.WriteLine("Illimitados - All Day");
        }

        static void SendWelcomeEmail(User user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Elysium Internet Cafe", "do-not-reply@elysium.com"));
            message.To.Add(new MailboxAddress(user.username, user.email));
            message.Subject = "Welcome to Elysium Internet Cafe! The Home of the Best Internet Cafe of the South!!!";

            message.Body = new TextPart("html")
            {
                Text = $"<h2>Welcome, {user.username}!</h2>" +
                       $"<p>Your account has been successfully created.</p>" +
                       $"<p>Here are your login details:</p>" +
                       $"<p><i>Username: {user.username}</p></i>" +
                       $"<p><i>Password: {user.password}</p></i>" +
                       $"<p>Balance: {user.balance}</p>"
            };

            using (var client = new SmtpClient()) 
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("aedfa5dfd8d09b", "3abc583983ef95");
                    client.Send(message);
                    Console.WriteLine("Welcome email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
