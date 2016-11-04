using SkillsTest.Domain.Enums;
using SkillsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Domain
{
    public class DefaultDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DefaultDbContext>
    {
        protected override void Seed(DefaultDbContext context)
        {
            var users = new List<User>()
            {
                new User() { Firstname = "Lee", Lastname = "Barlin", EmailAddress = "my@email.com", ClearTextPassword = "skills"},
                new User() { Firstname = "Joe", Lastname = "Powell", EmailAddress = "joe.powell@email.com", ClearTextPassword = "joe2"},
                new User() { Firstname = "Carol", Lastname = "Robertson", EmailAddress = "carol.robertson@email.com", ClearTextPassword = "carol3"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    Title = "What is Lorem Ipsum?",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Priority = Priority.Medium,
                    Status = Status.InProgress
                },
                new Ticket()
                {
                    Title = "Where does it come from?",
                    Description = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.",
                    Priority = Priority.Medium,
                    Status = Status.Open
                },
                new Ticket()
                {
                    Title = "Why do we use it?",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Priority = Priority.Low,
                    Status = Status.InProgress
                },
                new Ticket()
                {
                    Title = "Where can I get some?",
                    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.High,
                    Status = Status.Closed
                },
                new Ticket()
                {
                    Title = "Go with normal text",
                    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.High,
                    Status = Status.InProgress
                },
                new Ticket()
                {
                    Title = "Be cool",
                    Description = "Look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.High,
                    Status = Status.Closed
                },
                new Ticket()
                {
                    Title = "Anything embarrassing hidden in the middle of text",
                    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.Medium,
                    Status = Status.Closed
                },
                new Ticket()
                {
                    Title = "Making this the first true generator on the Internet",
                    Description = "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.High,
                    Status = Status.Open
                },

                new Ticket()
                {
                    Title = "The first true generator on the Internet",
                    Description = "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                    Priority = Priority.None,
                    Status = Status.InProgress
                },

                new Ticket()
                {
                    Title = "The Basics",
                    Description = "HTML is great for declaring static documents, but it falters when we try to use it for declaring dynamic views in web-applications. AngularJS lets you extend HTML vocabulary for your application. The resulting environment is extraordinarily expressive, readable, and quick to develop.",
                    Priority = Priority.Medium,
                    Status = Status.Open
                },

                new Ticket()
                {
                    Title = "Alternatives",
                    Description = "Other frameworks deal with HTML’s shortcomings by either abstracting away HTML, CSS, and/or JavaScript or by providing an imperative way for manipulating the DOM. Neither of these address the root problem that HTML was not designed for dynamic views.",
                    Priority = Priority.Low,
                    Status = Status.Open
                },

                new Ticket()
                {
                    Title = "Extensibility",
                    Description = "AngularJS is a toolset for building the framework most suited to your application development. It is fully extensible and works well with other libraries. Every feature can be modified or replaced to suit your unique development workflow and feature needs. Read on to find out how.",
                    Priority = Priority.High,
                    Status = Status.Open
                },
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
