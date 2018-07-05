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
    public class BehaviorUnitTests
    {

        [Fact]
        public void TestCanCreateBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCanCreateBQ")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);

                var results = context.BehaviorQuestions.Where(a => a.Content == "Content");

                Assert.Equal(1, results.Count());
            }

        }

        //[Fact]
        //public void TestCannotCreateBQ()
        //{
        //    DbContextOptions<FunemploymentDBContext> options =
        //     new DbContextOptionsBuilder<FunemploymentDBContext>()
        //     .UseInMemoryDatabase("TestCanReadBQ")
        //     .Options;

        //    using (FunemploymentDBContext context = new FunemploymentDBContext(options))
        //    {
        //        BQController bc = new BQController(context);

        //        var test = bc.Create();
        //        var test2 = bc.GetByID(1).Result;

        //        Assert.IsType<OkObjectResult>(test2);
        //    }
        //}

        [Fact]
        public void TestCanReadBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
         new DbContextOptionsBuilder<FunemploymentDBContext>()
         .UseInMemoryDatabase("TestCanReadBQ")
         .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);
                var test2 = bc.GetByID(1).Result;


                Assert.IsType<OkObjectResult>(test2);
            }
        }

        [Fact]
        public async void TestCannotReadBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCannotReadBQ")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);
                var test2 = bc.GetByID(7).Result;

                Assert.IsType<NotFoundResult>(test2);
            }

        }


        [Fact]
        public void TestCanUpdateBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCanUpdateBQ")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);

                BehaviorQuestion BQ2 = new BehaviorQuestion();
                BQ2.Content = "changed";


                var test2 = bc.Update(1, BQ2);

                var results = context.BehaviorQuestions.FirstOrDefault(a => a.ID == 1);


                Assert.Equal("changed", results.Content);
            }
        }



        [Fact]
        public void TestCannotUpdateBQ()
        {

            DbContextOptions<FunemploymentDBContext> options =
              new DbContextOptionsBuilder<FunemploymentDBContext>()
              .UseInMemoryDatabase("TestCannotUpdateBQ")
              .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);

                BehaviorQuestion BQ2 = new BehaviorQuestion();
                BQ2.ID = 2;
                BQ2.Content = "changed";


                var test2 = bc.Update(3, BQ2);
               var answer = test2.Result;

                Assert.IsType<CreatedAtRouteResult>(answer);
            }
        }

        [Fact]
        public void TestCanDestroyBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
                new DbContextOptionsBuilder<FunemploymentDBContext>()
                .UseInMemoryDatabase("TestCanDestroyBQ")
                .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);
                var test2 = bc.Destroy(1).Result;

                Assert.IsType<NoContentResult>(test2);

            }

        }

        [Fact]
        public void TestCannotDestroyBQ()
        {
            DbContextOptions<FunemploymentDBContext> options =
      new DbContextOptionsBuilder<FunemploymentDBContext>()
      .UseInMemoryDatabase("TestCannotDestroyBQ")
      .Options;

            using (FunemploymentDBContext context = new FunemploymentDBContext(options))
            {
                BehaviorQuestion BQ = new BehaviorQuestion();
                BQ.ID = 1;
                BQ.Content = "Content";


                BQController bc = new BQController(context);

                var test = bc.Create(BQ);
                var test2 = bc.Destroy(2).Result;

                Assert.IsType<NotFoundResult>(test2);

            }
        }
    }
}
