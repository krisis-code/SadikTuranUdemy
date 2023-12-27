﻿using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestDataFill (IApplicationBuilder app)
        {

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null ) 
            {
                context.Database.Migrate();

            }

            if(!context.Tags.Any()) 
            {
                context.Tags.AddRange(

                    new Entity.Tag { Text = "web programlama"},
                    
                    new Entity.Tag { Text = "backend" },
                    
                    new Entity.Tag { Text = "frontend" },
                    
                    new Entity.Tag { Text = "fullstack" },
                    
                    new Entity.Tag { Text = "c#" }

                    );

                context.SaveChanges();

            }

            if(!context.Users.Any() ) 
            {
                context.Users.AddRange(

                       new Entity.User { UserName = "krisis" },

                       new Entity.User { UserName = "hidescript" },

                       new Entity.User { UserName = "backthehole" },

                       new Entity.User { UserName = "cancanan" },

                       new Entity.User { UserName = "kazımcan" }

                       );

                context.SaveChanges();

            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(

                       new Entity.Post { 
                           Title = "Asp.net core",

                           Content = "ontrary to popular belief, Lorem Ipsum is not simply random text." +
                           " It has roots in a piece of classical Latin literature from 45 BC, making it " +
                           "over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                           "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                           " from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                           " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32" +
                           " and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero," +
                           " written in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                           "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line" +
                           " in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced" +
                           " below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" " +
                           "by Cicero are also reproduced in their exact original form, accompanied by English versions from " +
                           "the 1914 translation by H. Rackham.",

                           IsActive = true,
                           
                           PublishedOn = DateTime.Now.AddDays(-10),
                           
                           Tags=context.Tags.Take(3).ToList(),
                           
                           UserId = 1

                       },

                       new Entity.Post
                       {
                           Title = "Derinlemesine C#",

                           Content = "ontrary to popular belief, Lorem Ipsum is not simply random text." +
                           " It has roots in a piece of classical Latin literature from 45 BC, making it " +
                           "over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                           "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                           " from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                           " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32" +
                           " and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero," +
                           " written in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                           "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line" +
                           " in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced" +
                           " below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" " +
                           "by Cicero are also reproduced in their exact original form, accompanied by English versions from " +
                           "the 1914 translation by H. Rackham.",

                           IsActive = true,

                           PublishedOn = DateTime.Now.AddDays(-15),

                           Tags = context.Tags.Take(3).ToList(),

                           UserId = 2

                       },

                       new Entity.Post
                       {
                           Title = "Javascript Öğren",

                           Content = "ontrary to popular belief, Lorem Ipsum is not simply random text." +
                           " It has roots in a piece of classical Latin literature from 45 BC, making it " +
                           "over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                           "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                           " from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                           " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32" +
                           " and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero," +
                           " written in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                           "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line" +
                           " in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced" +
                           " below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" " +
                           "by Cicero are also reproduced in their exact original form, accompanied by English versions from " +
                           "the 1914 translation by H. Rackham.",

                           IsActive = true,

                           PublishedOn = DateTime.Now.AddDays(-20),

                           Tags = context.Tags.Take(3).ToList(),

                           UserId = 3

                       },
                       
                       new Entity.Post
                       {
                           Title = "C++ Data struct",

                           Content = "ontrary to popular belief, Lorem Ipsum is not simply random text." +
                           " It has roots in a piece of classical Latin literature from 45 BC, making it " +
                           "over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                           "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                           " from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                           " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32" +
                           " and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero," +
                           " written in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                           "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line" +
                           " in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced" +
                           " below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" " +
                           "by Cicero are also reproduced in their exact original form, accompanied by English versions from " +
                           "the 1914 translation by H. Rackham.",

                           IsActive = true,

                           PublishedOn = DateTime.Now.AddDays(-10),

                           Tags = context.Tags.Take(3).ToList(),

                           UserId = 3

                       },
                       
                       new Entity.Post
                       {
                           Title = "FullStack Development",

                           Content = "ontrary to popular belief, Lorem Ipsum is not simply random text." +
                           " It has roots in a piece of classical Latin literature from 45 BC, making it " +
                           "over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                           "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                           " from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                           " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32" +
                           " and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero," +
                           " written in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                           "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line" +
                           " in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced" +
                           " below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" " +
                           "by Cicero are also reproduced in their exact original form, accompanied by English versions from " +
                           "the 1914 translation by H. Rackham.",

                           IsActive = true,

                           PublishedOn = DateTime.Now.AddDays(-10),

                           Tags = context.Tags.Take(3).ToList(),

                           UserId = 1

                       }

                       );

                context.SaveChanges();

            }


        }
    }
}
