using SkillsTest.Domain.Helpers;
using SkillsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsTest.Web.ViewModels.Tickets
{
    public class IndexViewModel
    {
        public Page<Ticket> TicketsPaged { get; set; }
    }
}