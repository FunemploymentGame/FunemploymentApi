using System;
using Xunit;
using FunemploymentApi.Data;
using Microsoft.EntityFrameworkCore;
using FunemploymentApi.Models;
using System.Linq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        //Testing Database 
        [Fact]
        public async void DatabaseCanSave()
        {
            new DbContextOptions<FunemploymentDBContext> options =
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



            }

        }


        //Testing Technical Questions

        [Fact]
        public async void TestCreateTQ()
        {

        }

        [Fact]
        public async void TestReadTQ()
        {

        }

        [Fact]
        public async void TestUpdateTQ()
        {

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
