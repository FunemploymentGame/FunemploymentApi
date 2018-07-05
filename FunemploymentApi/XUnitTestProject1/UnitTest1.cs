using System;
using Xunit;
using FunemploymentApi.Data;
using Microsoft.EntityFrameworkCore;
using FunemploymentApi.Models;
using System.Linq;
using FunemploymentApi.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        //Testing Database 
        [Fact]
        public async void DatabaseCanSave()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("DBCanSave")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                //arange
                TechnicalQuestion TQ = new TechnicalQuestion();
                TQ.ProblemDomain = "Problem domain";

                //act
                await context.TechnicalQuestions.AddAsync(TQ);
                await context.SaveChangesAsync();

                var results = context.TechnicalQuestions.Where(t => t.ProblemDomain == "Problem domain");

                Assert.Equal(1, results.Count());

            }

        }


        //Testing Technical Questions

        [Fact]
        public async void TestCanCreateTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCanCreateTQ")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                TechnicalQuestion TQ = new TechnicalQuestion();
                TQ.ProblemDomain = "Problem Domain";
                TQ.Input = "Input";
                TQ.Output = "Output";
                TQ.Difficulty = 7;

                TQController tc = new TQController(context);

                 var test =  tc.Create(TQ);

                var results = context.TechnicalQuestions.Where(a => a.ProblemDomain == "Problem Domain");

                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public async void TestReadTQ()
        {

        }

        [Fact]
        public async void TestCanUpdateTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
         new DbContextOptionsBuilder<FunemploymentDBContext>()
         .UseInMemoryDatabase("TestCanCreateTQ")
         .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                TechnicalQuestion TQ = new TechnicalQuestion();
                TQ.ID = 1;
                TQ.ProblemDomain = "Problem Domain";
                TQ.Input = "Input";
                TQ.Output = "Output";
                TQ.Difficulty = 7;

                TQController tc = new TQController(context);

                var test = tc.Create(TQ);

                TechnicalQuestion TQ2 = new TechnicalQuestion();
                TQ2.ProblemDomain = "no Domain";
                TQ2.Input = "out";
                TQ2.Output = "in";
                TQ2.Difficulty = 7;

                var test2 = tc.Update(1, TQ2);
                var answer = test2.Result;

                Assert.IsType<NoContentResult>(answer);
            }
        }

        [Fact]
        public async void TestDestroyTQ()
        {

        }


        // Testing Behavior Questions

        [Fact]
        public async void TestCreateBQ()
        {

        }

        [Fact]
        public async void TestReadBQ()
        {

        }

        [Fact]
        public async void TestUpdateBQ()
        {

        }

        [Fact]
        public async void TestDestroyBQ()
        {

        }
    }
}
