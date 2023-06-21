using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class JournalDetailManager : IUserInterfaceManager
    {
        //stores the reference to the parent user interface manager.
        private IUserInterfaceManager _parentUI;
        //An instance of the JournalRepository class for retrieving journal data.
        private JournalRepository _journalRepository;
        //Stores Id of journal being managed
        private int _journalId;

        //constructor JournalDetailManager initializes the private fields based on the provided parameters: parentUI, connectionString, and journalId.
        public JournalDetailManager(IUserInterfaceManager parentUI, string connectionString, int journalId)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
            _journalId = journalId;
        }

        public IUserInterfaceManager Execute()
        {
            Journal journal = _journalRepository.Get(_journalId);
            Console.WriteLine($"{journal.Title} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Journal journal = _journalRepository.Get(_journalId);
            Console.WriteLine($"Title: {journal.Title}");
            Console.WriteLine($"Content: {journal.Content}");
            Console.WriteLine($"Publish Date and Time: {journal.CreateDateTime}");
           
            Console.WriteLine();
        }

    }
}

