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
    public class TechnicalUnitTests
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
        public void TestCanCreateTQ()
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

                var test = tc.Create(TQ);

                var results = context.TechnicalQuestions.Where(a => a.ProblemDomain == "Problem Domain");

                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public void TestCanReadTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
             new DbContextOptionsBuilder<FunemploymentDBContext>()
             .UseInMemoryDatabase("TestCanReadTQ")
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
                var test2 = tc.GetByID(1).Result;

                Assert.IsType<OkObjectResult>(test2);
            }
        }

        [Fact]
        public void TestCannotReadTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
       new DbContextOptionsBuilder<FunemploymentDBContext>()
       .UseInMemoryDatabase("TestCannotReadTQ")
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
                var test2 = tc.GetByID(7).Result;

                Assert.IsType<NotFoundResult>(test2);
            }
        }

        [Fact]
        public void TestCanUpdateTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
         new DbContextOptionsBuilder<FunemploymentDBContext>()
         .UseInMemoryDatabase("TestCanUpdateTQ")
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

                var results = context.TechnicalQuestions.FirstOrDefault(a => a.ID == 1);

                Assert.Equal("no Domain", results.ProblemDomain);

            }
        }

        [Fact]
        public void TestCanFailUpdateTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
         new DbContextOptionsBuilder<FunemploymentDBContext>()
         .UseInMemoryDatabase("TestCanFailUpdateTQ")
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

                var test2 = tc.Update(2, TQ2);
                var answer = test2.Result;

                Assert.IsType<CreatedAtRouteResult>(answer);
            }
        }

        [Fact]
        public void TestDestroyTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCanDestroyTQ")
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
                var test2 = tc.Destroy(1).Result;

                Assert.IsType<NoContentResult>(test2);

            }
        }

        [Fact]
        public void TestCannotDestroyTQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCannotDestroyTQ")
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
                var test2 = tc.Destroy(2).Result;

                Assert.IsType<NotFoundResult>(test2);
            }
        }
    }
}
