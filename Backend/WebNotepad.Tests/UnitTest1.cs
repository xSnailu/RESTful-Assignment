using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebNotepad.Models;

namespace WebNotepad.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void CreateDataBase(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<WebNotepadDBContext>()
               .UseInMemoryDatabase(databaseName: "WebNotepadDB")
               .Options;
            using var context = new WebNotepadDBContext(options);
            context.CurrentNotes.Add(new CurrentNote { Id = 1, Title = "Tytul1", Content = "Content1", Created = DateTime.Now, Modified = DateTime.Now, IsActive = true });
            context.CurrentNotes.Add(new CurrentNote { Id = 2, Title = "Tytul2", Content = "Content2", Created = DateTime.Now, Modified = DateTime.Now, IsActive = true });
            context.CurrentNotes.Add(new CurrentNote { Id = 3, Title = "Tytul3", Content = "Content3", Created = DateTime.Now, Modified = DateTime.Now, IsActive = true });
            context.ArchiveNotes.Add(new ArchiveNote { NoteId = 3, Title = "Tytul3", Content = "Content3", Created = DateTime.MinValue, Modified = DateTime.MinValue, IsActive = true });
            context.SaveChanges();
        }

        [TestMethod]
        public void GetAllNotes()
        {

        }

    }
}
